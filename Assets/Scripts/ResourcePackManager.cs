using System.IO;
using Assets.InventorySystem;
using Assets.Scripts.Data_Models;
using Assets.Scripts.Enums;
using UnityEngine;
using Block = Assets.Scripts.Data_Models.Block;

namespace Assets.Scripts
{
    public class ResourcePackManager : MonoBehaviour
    {
        public static ResourcePackManager Instance { get; private set; }

        public string TextureDefaultPath = Directory.GetCurrentDirectory() + "/texturepacks/Default/";

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
                BlockId = 1,
                BlockName = "Cobblestone",
                BlockTypeName = BlockType.FullSizeBlock,
                BlockMaterialType = MaterialType.FullSizeBlockMaterial,
                BlockTexturePath = texturesDefaultPath + "cobblestone.png",
                BlockDurability = 5,
                BlockDropId = 1,
                BlockDropMaxCount = 1
            };
            cobblestone.BlockSlug =
                $"item.block.{cobblestone.BlockName}_{cobblestone.BlockTypeName}:{cobblestone.BlockId}";
            cobblestone.BlockInfo = new InventorySystem.Items.Block
            {
                type = ItemType.Block,
                id = cobblestone.BlockId,
                name = cobblestone.BlockName,
                slug = cobblestone.BlockSlug
            };
            cobblestone.BlockInfo.itemProperties.Add(ItemProperties.Flammable);
            cobblestone.BlockInfo.itemProperties.Add(ItemProperties.Stackable);
            resourcePack.Blocks.Add(cobblestone);

            var furnace = new Block()
            {
                BlockId = 2,
                BlockName = "Furnace",
                BlockTypeName = BlockType.FullSizeBlock,
                BlockMaterialType = MaterialType.FullSizeBlockMaterial,
                BlockTexturePath = texturesDefaultPath + "furnace.png",
                BlockDurability = 5,
                BlockDropId = 2,
                BlockDropMaxCount = 1
            };
            furnace.BlockSlug =
                $"item.block.{furnace.BlockName}_{furnace.BlockTypeName}:{furnace.BlockId}";
            furnace.BlockInfo = new InventorySystem.Items.Block
            {
                type = ItemType.Block,
                id = furnace.BlockId,
                name = furnace.BlockName,
                slug = furnace.BlockSlug
            };
            furnace.BlockInfo.itemProperties.Add(ItemProperties.Craftable);
            furnace.BlockInfo.itemProperties.Add(ItemProperties.Flammable);
            furnace.BlockInfo.itemProperties.Add(ItemProperties.Stackable);
            resourcePack.Blocks.Add(furnace);

            var furnaceOn = new Block()
            {
                BlockId = 3,
                BlockName = "Furnace_On",
                BlockTypeName = BlockType.FullSizeBlock,
                BlockMaterialType = MaterialType.FullSizeBlockMaterial,
                BlockTexturePath = texturesDefaultPath + "furnace_on.png"
            };
            furnaceOn.BlockSlug =
                $"item.block.{furnaceOn.BlockName}_{furnaceOn.BlockTypeName}:{furnaceOn.BlockId}";
            furnaceOn.BlockInfo = new InventorySystem.Items.Block
            {
                type = ItemType.Block,
                id = furnaceOn.BlockId,
                name = furnaceOn.BlockName,
                slug = furnaceOn.BlockSlug
            };
            furnaceOn.BlockInfo.itemProperties.Add(ItemProperties.Flammable);
            furnaceOn.BlockInfo.itemProperties.Add(ItemProperties.Stackable);
            resourcePack.Blocks.Add(furnaceOn);

            var dirt = new Block()
            {
                BlockId = 4,
                BlockName = "Dirt",
                BlockTypeName = BlockType.FullSizeBlock,
                BlockMaterialType = MaterialType.FullSizeBlockMaterial,
                BlockTexturePath = texturesDefaultPath + "dirt.png",
                BlockDurability = 3,
                BlockDropId = 4,
                BlockDropMaxCount = 1
            };
            dirt.BlockSlug =
                $"item.block.{dirt.BlockName}_{dirt.BlockTypeName}:{dirt.BlockId}";
            dirt.BlockInfo = new InventorySystem.Items.Block
            {
                type = ItemType.Block,
                id = dirt.BlockId,
                name = dirt.BlockName,
                slug = dirt.BlockSlug
            };
            dirt.BlockInfo.itemProperties.Add(ItemProperties.Flammable);
            dirt.BlockInfo.itemProperties.Add(ItemProperties.Stackable);
            resourcePack.Blocks.Add(dirt);

            var sand = new Block()
            {
                BlockId = 5,
                BlockName = "Sand",
                BlockTypeName = BlockType.FullSizeBlock,
                BlockMaterialType = MaterialType.FullSizeBlockMaterial,
                BlockTexturePath = texturesDefaultPath + "sand.png",
                BlockDurability = 3,
                BlockDropId = 5,
                BlockDropMaxCount = 1
            };
            sand.BlockSlug =
                $"item.block.{sand.BlockName}_{sand.BlockTypeName}:{sand.BlockId}";
            sand.BlockInfo = new InventorySystem.Items.Block
            {
                type = ItemType.Block,
                id = sand.BlockId,
                name = sand.BlockName,
                slug = sand.BlockSlug
            };
            sand.BlockInfo.itemProperties.Add(ItemProperties.Pouring);
            sand.BlockInfo.itemProperties.Add(ItemProperties.Flammable);
            sand.BlockInfo.itemProperties.Add(ItemProperties.Stackable);
            resourcePack.Blocks.Add(sand);

            var oak_log = new Block()
            {
                BlockId = 6,
                BlockName = "Oak Log",
                BlockTypeName = BlockType.FullSizeBlock,
                BlockMaterialType = MaterialType.FullSizeBlockMaterial,
                BlockTexturePath = texturesDefaultPath + "oak_log.png",
                BlockDurability = 4,
                BlockDropId = 6,
                BlockDropMaxCount = 1
            };
            oak_log.BlockSlug =
                $"item.block.{oak_log.BlockName}_{oak_log.BlockTypeName}:{oak_log.BlockId}";
            oak_log.BlockInfo = new InventorySystem.Items.Block
            {
                type = ItemType.Block,
                id = oak_log.BlockId,
                name = oak_log.BlockName,
                slug = oak_log.BlockSlug
            };
            oak_log.BlockInfo.itemProperties.Add(ItemProperties.Flammable);
            oak_log.BlockInfo.itemProperties.Add(ItemProperties.Stackable);
            resourcePack.Blocks.Add(oak_log);

            return resourcePack;
        }
    }
}
