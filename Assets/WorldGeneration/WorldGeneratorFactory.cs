using System;
using Assets.Scripts.Enums;
using Assets.WorldGeneration.Implementations;
using Assets.WorldGeneration.Interfaces;

namespace Assets.WorldGeneration
{
    public static class WorldGeneratorFactory
    {
        public static IWorldGenerator GetWorldGenerator(WorldGenerationType generationType)
        {
            switch (generationType)
            {
                case WorldGenerationType.Flat:
                    return new FlatWorldTypeGeneration();
                case WorldGenerationType.Perlin:
                    return new PerlinNoiseGeneration();
                default:
                    throw new ArgumentOutOfRangeException(nameof(generationType));
            }
        }
    }
}
