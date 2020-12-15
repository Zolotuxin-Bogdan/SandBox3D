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
        var blockDto = new BlockDto()
        {
            BlockId = 0,
            Position = _spawnPosition
        };
        blockDtoList.Add(blockDto);
        for (var x = 0; x < _worldSize; x++)
        {
            for (var z = 0; z < _worldSize; z++)
            {
                _spawnPosition.z = z;
                blockDto.Position = _spawnPosition;
                blockDtoList.Add(blockDto);
            }

            _spawnPosition.z = 0;
            _spawnPosition.x = x;
            blockDto.Position = _spawnPosition;
            blockDtoList.Add(blockDto);
        }

        return blockDtoList;
    }
}
