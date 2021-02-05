using System.Collections.Generic;
using Assets.Scripts.DTO;
using Assets.WorldGeneration.Interfaces;
using UnityEngine;

namespace Assets.WorldGeneration.Implementations
{
    public class PerlinNoiseGeneration : IWorldGenerator
    {
        public int PerlinTextureWidth = 256;
        public int PerlinTextureHeight = 256;

        public float Scale = 5f;

        public float OffsetX = 100f;
        public float OffsetY = 100f;

        public int MaxHeightmapHeight = 32;
        public int WorldBaseHeight = 10;

        public PerlinNoiseGeneration()
        {
            OffsetX = Random.Range(0, 99999);
            OffsetY = Random.Range(0, 99999);
        }

        Texture2D GenerateTexture()
        {
            Texture2D texture = new Texture2D(PerlinTextureWidth, PerlinTextureHeight);

            for (var x = 0; x < PerlinTextureWidth; x++)
            {
                for (var y = 0; y < PerlinTextureHeight; y++)
                {
                    Color color = CalculateColor(x, y);
                    texture.SetPixel(x, y, color);
                }
            }

            texture.Apply();
            return texture;
        }

        Color CalculateColor(int x, int y)
        {
            float xCoord = (float)x / PerlinTextureWidth * Scale + OffsetX;
            float yCoord = (float)y / PerlinTextureHeight * Scale + OffsetY;

            float sample = Mathf.PerlinNoise(xCoord, yCoord);
            return new Color(sample, sample, sample);
        }

        float GetGrayScale(Texture2D texture, int x, int y)
        {
            return texture.GetPixel(x, y).grayscale;
        }


        public List<BlockDto> GetBlocksDto()
        {
            var blockDtoList = new List<BlockDto>();
            var texture = GenerateTexture();
            for (var x = 0; x < 30; x++)
            {
                for (var y = 0; y < 30; y++)
                {
                    var grayScale = GetGrayScale(texture, x, y);
                    var blockHeight = Mathf.FloorToInt(grayScale * MaxHeightmapHeight); // + WorldBaseHeight;
                    blockDtoList.Add(new BlockDto()
                    {
                        BlockId = 1,
                        Position = new Vector3(x, blockHeight, y)
                    });
                    for (var i = 0; i < blockHeight; i++)
                    {
                        blockDtoList.Add(new BlockDto()
                        {
                            BlockId = 1,
                            Position = new Vector3(x, i, y)
                        });
                    }
                }
            }
            
            return blockDtoList;
        }


    }
}
