using System.Linq;
using Assets.InventorySystem;
using Assets.InventorySystem.Items;
using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
using Assets.StorageSystem.StorageProviders;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneEditor
    {

        MeshProvider meshLoader;
        ResourcePack resource;
        public SceneEditor()
        {
            meshLoader = new MeshProvider();
            resource = ResourcePackStorageProvider.Instance.LoadResourcePack();
        }
        
        public void AddItem(BaseItem item, Vector3 spawnPosition) {
            
            var itemBox = new GameObject("ItemBox");
            var rig = itemBox.AddComponent<Rigidbody>();
            rig.drag = 1;
            rig.freezeRotation = true;
            var collider = itemBox.AddComponent<BoxCollider>();
            collider.center = new Vector3(0, -.5f, 0);
            collider.size = new Vector3(1, 0, 1);
            
            if (item.type == Enums.ItemType.Block) {
                var blockInfo = resource.Blocks.FirstOrDefault(t => t.BlockSlug.Equals(item.slug));
                var instance = Object.Instantiate(BlockTypeManager.Instance.GetBlockTypeByName(blockInfo.BlockTypeName.ToString()));
                
                instance.GetComponent<Renderer>().material =
                    BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
                
                var blockTexture = new Texture2D(48, 48, TextureFormat.RGBA32, false);
                
                blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
                blockTexture.filterMode = FilterMode.Point;
                instance.GetComponent<Renderer>().material.SetTexture("_MainTex", blockTexture);

                var pickup = instance.AddComponent<ItemPickup>();
                var animation = instance.AddComponent<ItemAnimation>();
                pickup.pickUpRadius = .7f;
                pickup.item = item;
                animation.rotationY = .18f;
                animation.moveY = .0005f;
                
                instance.transform.localPosition = spawnPosition;
                instance.transform.SetParent(itemBox.transform);
            }
            
            itemBox.transform.localPosition = spawnPosition;

            rig.velocity = Vector3.forward;
        }

        // public void AddItem(BaseItem item)
        // {
        //     if (item == null)
        //         throw new System.ArgumentNullException(nameof(item));

        //     var _item = new GameObject(item.name);
        //     _item.AddComponent<Rigidbody>();
        //     _item.AddComponent<MeshRenderer>();
        //     //_item.AddComponent<Item>().item = item;
        //     _item.AddComponent<MeshFilter>().mesh = meshLoader.ImportMeshBySlug(item.slug) ?? 
        //                                             throw new System.Exception(
        //                                                 $"MeshImportingError: Mesh by {nameof(item.slug)} not found!"
        //                                             );
        // }

        public bool AddItem(BlockDto blockDto) {
            
            var itemBox = new GameObject("ItemBox");
            var rig = itemBox.AddComponent<Rigidbody>();
            rig.drag = 1;
            rig.freezeRotation = true;
            var collider = itemBox.AddComponent<BoxCollider>();
            collider.center = new Vector3(0, -.5f, 0);
            collider.size = new Vector3(1, 0, 1);

            try
            {
                var resources = ResourcePackStorageProvider.Instance.LoadResourcePack();
                var blockInfo = resources.Blocks.FirstOrDefault(t => t.BlockId.Equals(blockDto.BlockId));
                var spawnedBlock = Object.Instantiate(BlockTypeManager.Instance.GetBlockTypeByName($"{blockInfo.BlockTypeName}"), blockDto.Position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                spawnedBlock.name = blockInfo.BlockName;
                BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
                var blockTexture = new Texture2D(16, 16, TextureFormat.RGBA32, false);
                blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
                blockTexture.filterMode = FilterMode.Point;
                spawnedBlock.GetComponent<Renderer>().material.SetTexture("_MainTex", blockTexture);

                if (blockInfo.BlockInfo.itemProperties.Contains(ItemProperties.Craftable)) {

                }

                if (blockInfo.BlockInfo.itemProperties.Contains(ItemProperties.Flammable)) {

                }

                if (blockInfo.BlockInfo.itemProperties.Contains(ItemProperties.Stackable)) {

                }

                if (blockInfo.BlockInfo.itemProperties.Contains(ItemProperties.Transparent)) {

                }

                if (blockInfo.BlockInfo.itemProperties.Contains(ItemProperties.Unexploaded)) {
                    
                }


                var item = new InventorySystem.Items.Block
                {
                    amount = 1, 
                    gravity = false,
                    luminosity = false,
                    type = Enums.ItemType.Block,
                    id = blockInfo.BlockId,
                    name = blockInfo.BlockName, 
                    slug = $"item.block.{blockInfo.BlockName}_{blockInfo.BlockTypeName}:{blockInfo.BlockId}"
                }; 
                spawnedBlock.AddComponent<Item>().item = (BaseItem)item;

                spawnedBlock.transform.localPosition = blockDto.Position;
                spawnedBlock.transform.SetParent(itemBox.transform);

                itemBox.transform.localPosition = blockDto.Position;
                return true;    
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                return false;
            }
       
        }

        protected byte[] GetTextureBytes(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }
    }
}
