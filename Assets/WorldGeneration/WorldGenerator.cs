using System.IO;
using System.Linq;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int WorldSize { get; set; } = 100;
    public ResourcePack ResourcePack;

    public void LoadResourcePack()
    {
        ResourcePack = ResourcePackStorageProvider.Instance.LoadResourcePack();
        GenerateWorld();

    }
    public void GenerateWorld()
    {
        var blockDtoList = new FlatWorldTypeGeneration(WorldSize).GetBlocksDto();
        foreach (var blockDto in blockDtoList)
        {
            var blockInfo = ResourcePack.Blocks.FirstOrDefault(t => t.BlockId.Equals(blockDto.BlockId));
            var createdBlock = Instantiate(BlockTypeManager.Instance.GetBlockTypeByName(blockInfo.BlockTypeName.ToString()), blockDto.Position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            createdBlock.name = blockInfo.BlockName;
            createdBlock.GetComponent<Renderer>().material =
                BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
            var blockTexture = new Texture2D(48, 48, TextureFormat.RGBA32, false);
            blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
            blockTexture.filterMode = FilterMode.Point;
            createdBlock.GetComponent<Renderer>().material.SetTexture("_MainTex", blockTexture);
        }
    }

    private byte[] GetTextureBytes(string path)
    {
        return File.ReadAllBytes(path);
    }
}
