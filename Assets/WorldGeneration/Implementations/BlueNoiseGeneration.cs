using System.Collections.Generic;
using Assets.Scripts.DTO;
using Assets.WorldGeneration.Interfaces;
using UnityEngine;

namespace Assets.WorldGeneration.Implementations
{
    public class BlueNoiseGeneration : IWorldGenerator
    {
        private readonly int _mapWidth;
        private readonly int _mapHeight;

        private const int DENSITY = 3;

        private Texture2D _noiseMap;

        public BlueNoiseGeneration(int mapWidth, int mapHeight, Texture2D perlinNoiseMap)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _noiseMap = perlinNoiseMap;
        }

        public Texture2D GenerateBlueNoise()
        {
            Texture2D texture = new Texture2D(_mapWidth, _mapHeight);

            for (int y = 0; y < _mapHeight; y++)
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    texture.SetPixel(x, y, Color.black);
                }
            }

            for (var xCoord = 0; xCoord < _mapWidth; xCoord++)
            {
                for (var yCoord = 0; yCoord < _mapHeight; yCoord++)
                {
                    var posX = Random.Range(0, _mapWidth);
                    var posY = Random.Range(0, _mapHeight);
                    var frequency = Mathf.PerlinNoise(posX, posY);
                    texture.SetPixel(posX, posY, new Color(frequency, frequency, frequency));
                }
            }

            texture.Apply();
            return texture;
        }

        public Texture2D GenerateTexture()
        {
            Texture2D texture = new Texture2D(_mapWidth, _mapHeight);

//            for (int y = 0; y < _mapHeight; y++)
//            {
//                for (int x = 0; x < _mapWidth; x++)
//                {
//                    texture.SetPixel(x, y, Color.black);
//                }
//            }

            for (int yc = 0; yc < _mapHeight; yc++)
            {
                for (int xc = 0; xc < _mapWidth; xc++)
                {
                    float max = 0;
                    int posX = 0;
                    int posY = 0;
                    // существуют более эффективные алгоритмы
                    for (int yn = yc - DENSITY; yn <= yc + DENSITY; yn++)
                    {
                        for (int xn = xc - DENSITY; xn <= xc + DENSITY; xn++)
                        {
                            float e = _noiseMap.GetPixel(yn + yc, xn + xc).b;
                            if (e > max)
                            {
                                max = e;
                                posX = xn + xc;
                                posY = yn + yc;
                            }
                        }
                    }

                    //xc += DENSITY / 2;
                    //texture.SetPixel(posX, posY, new Color(0, max, max));
                    if (_noiseMap.GetPixel(yc, xc).b == max)
                    {
                        // размещаем дерево в xc,yc
                        texture.SetPixel(posY, posX, new Color(max, max, max));
                    }
                }
            }

            texture.Apply();
            return texture;
        }

        public Texture2D GenerateBlueNoiseMap()
        {
            Texture2D blueNoiseMap = new Texture2D(_mapWidth, _mapHeight);
            for (var x = 0; x < _mapWidth; x++)
            {
                for (var y = 0; y < _mapHeight; y++)
                {
                    var maxFrequency = CalculateMaxFrequency(x, y);
                    if (_noiseMap.GetPixel(x, y).b.Equals(maxFrequency))
                    {
                        blueNoiseMap.SetPixel(x, y, new Color(maxFrequency, maxFrequency, maxFrequency));
                    }
                    /*if (_perlinNoiseMap.GetPixel(x, y))
                    Color color = CalculatePixelColor(x, y);
                    blueNoiseMap.SetPixel(x, y, color);*/
                }
            }

            blueNoiseMap.Apply();
            return blueNoiseMap;
        }

        private float CalculateMaxFrequency(int x, int y)
        {
            float maximum = 0f;
            for (var yCoord = y - DENSITY; yCoord <= y + DENSITY; yCoord++)
            {
                for (var xCoord = x - DENSITY; xCoord <= x + DENSITY; xCoord++)
                {
                    var sample = _noiseMap.GetPixel(yCoord, xCoord).b;
                    if (sample > maximum)
                    {
                        maximum = sample;
                    }
                }
            }
            return maximum;
        }

        float GetGrayScale(Texture2D texture, int x, int y)
        {
            return texture.GetPixel(x, y).grayscale;
        }

        public List<BlockDto> GetBlocksDto()
        {
            var blockDtoList = new List<BlockDto>();
            _noiseMap = GenerateBlueNoise();
            var texture = GenerateTexture();
            for (var x = 0; x < 100; x++)
            {
                for (var y = 0; y < 100; y++)
                {
                    var grayScale = GetGrayScale(texture, x, y);
                    var blockHeight = Mathf.FloorToInt(grayScale * 48); // + WorldBaseHeight;
                    blockDtoList.Add(new BlockDto()
                    {
                        BlockId = 1,
                        Position = new Vector3(x, blockHeight, y)
                    });
                    //
                    // Fill all space from up to down
                    //
                    /*for (var i = 0; i < blockHeight; i++)
                    {
                        blockDtoList.Add(new BlockDto()
                        {
                            BlockId = 1,
                            Position = new Vector3(x, i, y)
                        });
                    }*/
                }
            }

            return blockDtoList;
        }
    }
}