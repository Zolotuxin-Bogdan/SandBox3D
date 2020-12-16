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
            var createdBlock = Instantiate(BlockTypeManager.Instance.GetBlockTypeByName(blockInfo.BlockTypeName.ToString()), blockDto.Position, Quaternion.identity);
            createdBlock.GetComponent<Renderer>().material = 
                BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
            WWW www = new WWW(blockInfo.BlockTexturePath);
            Texture2D texTmp = new Texture2D(16, 16, TextureFormat.DXT5, false);
            //LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     
            www.LoadImageIntoTexture(texTmp);
            createdBlock.GetComponent<Renderer>().material.SetTexture("_MainTex", texTmp);
        }
    }
}
