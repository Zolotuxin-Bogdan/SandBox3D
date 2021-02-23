using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DTO;
using UnityEngine;

namespace Assets.WorldGeneration.Implementations
{
    public class StaticTree : Tree
    {
        public override List<BlockDto> GenerateDtoList(Vector3 position)
        {
            var maxStemHeight = position.y + 5;
            var minFoliageHeight = position.y + 4;
            var maxFoliageHeight = position.y + 8;
            var minFoliageLength = position.x - 2;
            var maxFoliageLength = position.x + 3;
            List<BlockDto> tree = new List<BlockDto>();
            for (var i = position.y; i < maxStemHeight; i++)
            {
                tree.Add(new BlockDto
                {
                    BlockId = 6,
                    Position = new Vector3(position.x, i, position.z)
                });
            }
            for (var y = minFoliageHeight; y < maxFoliageHeight; y++)
            {
                for (var x = minFoliageLength; x < maxFoliageLength; x++)
                {
                    Debug.Log(y-(maxFoliageHeight));
                    if (maxFoliageHeight-y <= 2){
                        if (maxFoliageLength-x == 5) continue;
                        if (maxFoliageLength-x == 1) break;
                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z)
                        });

                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z - 1)
                        });

                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z + 1)
                        });
                    }
                    else{
                        if (y == minFoliageHeight)
                        {
                            if (maxFoliageLength-x != 3)
                            {
                                tree.Add(new BlockDto
                                {
                                    BlockId = 7,
                                    Position = new Vector3(x, y, position.z)
                                });
                            }
                        }
                        else {
                            tree.Add(new BlockDto
                            {
                                BlockId = 7,
                                Position = new Vector3(x, y, position.z)
                            });
                        }

                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z - 1)
                        });

                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z + 1)
                        });

                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z + 2)
                        });

                        tree.Add(new BlockDto
                        {
                            BlockId = 7,
                            Position = new Vector3(x, y, position.z - 2)
                        });
                    }
                }
            }

            return tree;
        }
    }
}