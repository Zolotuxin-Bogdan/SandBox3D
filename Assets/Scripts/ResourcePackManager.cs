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
            BlockTypeName = BlockType.SingleTexture,
            BlockMaterialType = MaterialType.SingleTextureMaterial,
            BlockTexturePath = texturesDefaultPath + "cobblestone.png"
        };
        resourcePack.Blocks.Add(cobblestone);

        return resourcePack;
    }
}
