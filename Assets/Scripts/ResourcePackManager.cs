using System.IO;
using UnityEngine;

public class ResourcePackManager : MonoBehaviour
{
    public static ResourcePackManager Instance { get; private set; }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    

    public ResourcePack CreateResourcePack()
    {
        var texturesDefaultPath = Directory.GetCurrentDirectory() + "\\Textures" + "\\Default\\";
        var resourcePack = new ResourcePack();
        var cobblestone = new Block()
        {
            BlockId = 0,
            BlockName = "Cobblestone",
            BlockTypeName = BlockType.FullSizeBlock,
            BlockMaterialType = MaterialType.FullSizeBlockMaterial,
            BlockTexturePath = texturesDefaultPath + "cobblestone.png"
        };
        resourcePack.Blocks.Add(cobblestone);
        var furnance = new Block()
        {
            BlockId = 1,
            BlockName = "Furnance",
            BlockTypeName = BlockType.FullSizeBlock,
            BlockMaterialType = MaterialType.FullSizeBlockMaterial,
            BlockTexturePath = texturesDefaultPath + "furnance.png"
        };
        resourcePack.Blocks.Add(furnance);
        var furnanceOn = new Block()
        {
            BlockId = 2,
            BlockName = "Furnance_On",
            BlockTypeName = BlockType.FullSizeBlock,
            BlockMaterialType = MaterialType.FullSizeBlockMaterial,
            BlockTexturePath = texturesDefaultPath + "furnance_on.png"
        };
        resourcePack.Blocks.Add(furnanceOn);
        return resourcePack;
    }
}
