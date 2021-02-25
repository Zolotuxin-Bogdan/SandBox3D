using System.Collections.Generic;
using Assets.Scripts.DTO;
using Assets.WorldGeneration.Interfaces;
using UnityEngine;

namespace Assets.WorldGeneration.Implementations
{
    public class BlueNoiseGeneration
    {
        private readonly int _mapWidth;
        private readonly int _mapHeight;

        private const int DENSITY = 4;

        public BlueNoiseGeneration(int mapWidth, int mapHeight)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
        }

        public Texture2D NoiseGen()
        {
            // Generate base noise for extracting blue noise
            var sample = GenerateBlueNoise();
            // Create blue noise texture
            Texture2D texture = new Texture2D(_mapWidth, _mapHeight);
            List<Vector2> pixels = new List<Vector2>();
            // Set texture default frequency to minimal
            /*
             * uncomment if want to bold empty pixels
             *
             for (int y = 0; y < _mapHeight; y++)
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    texture.SetPixel(x, y, Color.black);
                }
            }*/
            // Write higher frequency to texture
            for (var yCoord = 0; yCoord < _mapHeight; yCoord++)
            {
                for (var xCoord = 0; xCoord < _mapWidth; xCoord++)
                {
                    float maxFreq = 0;
                    var offsetX = 0;
                    var offsetY = 0;
                    for (int yR = yCoord - DENSITY; yR < yCoord + DENSITY; yR++)
                    {
                        for (int xR = xCoord - DENSITY; xR < xCoord + DENSITY; xR++)
                        {
                            var e = sample.GetPixel(xR, yR).b;
                            if (e > maxFreq)
                            {
                                maxFreq = e;
                                offsetX = xR;
                                offsetY = yR;
                            }
                        }
                    }

                    if (pixels.Count > 1)
                        if (pixels.Exists(p => (offsetX - p.x) <= DENSITY && (offsetY - p.y) <= DENSITY))
                            continue;
                    texture.SetPixel(offsetX, offsetY, new Color(maxFreq, maxFreq, maxFreq));
                    pixels.Add(new Vector2(offsetX, offsetY));
                }
            }

            texture.Apply();
            return texture;
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
    }
}