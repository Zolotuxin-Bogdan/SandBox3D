using System;
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

        public float Scale = 3f;

        public float OffsetX = 100f;
        public float OffsetY = 100f;

        public int MaxHeightMapHeight = 48;
        public int WorldBaseHeight = 10;
        public int WorldSize = 100;

        public PerlinNoiseGeneration()
        {
            OffsetX = UnityEngine.Random.Range(0, 99999);
            OffsetY = UnityEngine.Random.Range(0, 99999);
        }

        public Texture2D GenerateTexture()
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
            var xCoord = (float)x / PerlinTextureWidth * Scale + OffsetX;
            var yCoord = (float)y / PerlinTextureHeight * Scale + OffsetY;

            var sample = Mathf.PerlinNoise(xCoord, yCoord)
                         + Convert.ToSingle(0.5 * Mathf.PerlinNoise(2 * xCoord, 2 * yCoord))
                         + Convert.ToSingle(0.25 * Mathf.PerlinNoise(4 * xCoord, 4 * yCoord));
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
            for (var x = 0; x < WorldSize; x++)
            {
                for (var y = 0; y < WorldSize; y++)
                {
                    var grayScale = GetGrayScale(texture, x, y);
                    var blockHeight = Mathf.FloorToInt(grayScale * MaxHeightMapHeight); // + WorldBaseHeight;
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
