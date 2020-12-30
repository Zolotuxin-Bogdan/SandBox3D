﻿using System.IO;
using UnityEngine;

public class ResourcePackManager : MonoBehaviour
{
    public static ResourcePackManager Instance { get; private set; }

    public string TextureDefaultPath = Directory.GetCurrentDirectory() + "/texturepacks/Default";

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

    //////////////////////////////////////////////////////////// DELETE(FOR TESTING)
    public void UnpackTextures()
    {
        BundleUnpacker unpacker = new BundleUnpacker();
        unpacker.UnpackTextures();
    }
    ////////////////////////////////////////////////////////////

    public ResourcePack CreateResourcePack()
    {
        var xmlConfig = ConfigLoader.GetConfig();
        var texturesPathNode = xmlConfig.SelectSingleNode("XML/Configuration/Path/Textures");
        var pathForUnpack = TextureDefaultPath;
        if (texturesPathNode != null)
        {
            pathForUnpack = texturesPathNode.InnerText;
        }
        var texturesDefaultPath = Directory.GetCurrentDirectory() + pathForUnpack;
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
