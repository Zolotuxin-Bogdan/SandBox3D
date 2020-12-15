using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int WorldSize { get; set; } = 100;
    public ResourcePack ResourcePack;

    public void LoadResourcePack()
    {
        ResourcePack = ResourcePackStorageProvider.Instance.LoadResourcePack();

    }
    public void GenerateWorld()
    {
        var blockDtoList = new FlatWorldTypeGeneration(WorldSize).GetBlocksDto();
        foreach (var blockDto in blockDtoList)
        {
            var blockInfo = ResourcePack.Blocks.FirstOrDefault(t => t.BlockId.Equals(blockDto.BlockId));
            var createdBlock = Instantiate(BlockTypeManager.Instance.GetBlockTypeByName(blockInfo.BlockTypeName.ToString()), blockDto.Position, Quaternion.identity);
            createdBlock.GetComponent<Renderer>().material = blockInfo.BlockMaterial;
        }
    }
}
