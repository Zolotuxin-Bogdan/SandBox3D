using System.Collections.Generic;
using UnityEngine;

public class FlatWorldTypeGeneration : IGenerator
{
    private readonly int _worldSize;
    private Vector3 _spawnPosition = new Vector3(0, 0, 0);

    public FlatWorldTypeGeneration(int worldSize)
    {
        _worldSize = worldSize;
    }

    public List<BlockDto> GetBlocksDto()
    {
        var blockDtoList = new List<BlockDto>();
        for (var x = 0; x < _worldSize; x++)
        {
            BlockDto blockDto;
            for (var z = 0; z < _worldSize; z++)
            {
                _spawnPosition.z = z;
                blockDto = new BlockDto()
                {
                    BlockId = z%3,
                    Position = _spawnPosition
                }; ;
                blockDtoList.Add(blockDto);
            }
            _spawnPosition.x = x+1;
        }

        return blockDtoList;
    }
}
