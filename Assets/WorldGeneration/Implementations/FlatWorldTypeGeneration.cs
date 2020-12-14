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

    public List<Vector3> GetBlockPositions()
    {
        var positionsList = new List<Vector3>();
        positionsList.Add(_spawnPosition);
        for (var x = 0; x < _worldSize; x++)
        {
            for (var z = 0; z < _worldSize; z++)
            {
                _spawnPosition.z = z;
                positionsList.Add(_spawnPosition);
            }

            _spawnPosition.z = 0;
            _spawnPosition.x = x;
            positionsList.Add(_spawnPosition);
        }

        return positionsList;
    }
}
