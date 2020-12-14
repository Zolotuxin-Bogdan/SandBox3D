using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int WorldSize { get; set; } = 100;
    public GameObject Block;
    //public ResourcePack ResourcePack = LoadSystem.LoadResourcePack;

    void Start()
    {
        GenerateWorld();
    }
    public void GenerateWorld()
    {
        var blocksSpawnPositions = new FlatWorldTypeGeneration(WorldSize).GetBlockPositions();
        foreach (var blocksSpawnPosition in blocksSpawnPositions)
        {
            Instantiate(Block, blocksSpawnPosition, Block.transform.rotation);
        }
    }
}
