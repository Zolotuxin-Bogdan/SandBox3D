using System.Collections.Generic;
using Assets.Scripts.DTO;
using UnityEngine;

namespace Assets.WorldGeneration.Implementations
{
    public class StaticTree : Tree
    {
        public override List<BlockDto> GenerateDtoList(Vector3 position)
        {
            List<BlockDto> tree = new List<BlockDto>();
            for (var i = position.y; i < position.y + 5; i++)
            {
                tree.Add(new BlockDto
                {
                    BlockId = 6,
                    Position = new Vector3(position.x, i, position.z)
                });
            }
            Debug.Log(tree.Count);
            for (var i = position.y + 4; i < position.y + 6; i++)
            {
                for (var j = position.x + 1; j < position.x + 4; j++)
                {
                    tree.Add(new BlockDto
                    {
                        BlockId = 7,
                        Position = new Vector3(j, i, position.z)
                    });

                    tree.Add(new BlockDto
                    {
                        BlockId = 7,
                        Position = new Vector3(-j, i, position.z)
                    });

                    tree.Add(new BlockDto
                    {
                        BlockId = 7,
                        Position = new Vector3(j, i, position.z + 1)
                    });

                    tree.Add(new BlockDto
                    {
                        BlockId = 7,
                        Position = new Vector3(-j, i, position.z + 1)
                    });
                }
            }

            return tree;
        }
    }
}