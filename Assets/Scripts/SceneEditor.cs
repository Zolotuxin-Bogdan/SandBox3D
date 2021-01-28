using System.Linq;
using Assets.InventorySystem;
using Assets.InventorySystem.Items;
using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
using Assets.StorageSystem.StorageProviders;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneEditor : MonoBehaviour
    {

        MeshProvider meshLoader;
        ResourcePack resource;
        public static SceneEditor instance;
        public RuntimeAnimatorController itemAnimatorController;
        protected void Start()
        {
            instance = this;
            meshLoader = new MeshProvider();
            resource = ResourcePackStorageProvider.Instance.LoadResourcePack();
        }

        #region DEBUG
            // When player drop item
            public void AddItem(Vector3 spawnPosition) {
                
                // Item container initialization
                GameObject itemBox = new GameObject();
                itemBox.name = $"itemBox_{itemBox.GetInstanceID()}";
                Rigidbody physic = itemBox.AddComponent<Rigidbody>();
                physic.drag = 1;
                physic.freezeRotation = true;
                BoxCollider collider = itemBox.AddComponent<BoxCollider>();
                collider.center = new Vector3(0, -.5f, 0);
                collider.size = new Vector3(1, 0, 1);
                itemBox.transform.localPosition = spawnPosition;

                // Item initialization
                var item_ = GameObject.CreatePrimitive(PrimitiveType.Cube);
                item_.GetComponent<BoxCollider>().enabled = false;
                item_.transform.localScale = new Vector3(.3f, .3f, .3f);
                
                var pickup = item_.AddComponent<ItemPickup>();
                pickup.pickUpRadius = .7f;
                pickup.item = new BaseItem();
                pickup.item1 = new UIItem();
                pickup.pickupDelay = 3;
                
                var animator = item_.AddComponent<Animator>();
                animator.runtimeAnimatorController = itemAnimatorController;
                animator.applyRootMotion = true;

                item_.transform.localPosition = spawnPosition;
                item_.transform.SetParent(itemBox.transform);
                
                physic.velocity = Vector3.forward * 10;
            }
        #endregion
        #region RELEASE
        
        /// <summary>
        /// adds an object to the game scene that is a reduced copy of the original object
        /// </summary>
        /// <param name="itemInfo">information about the item that will be added to the scene</param>
        /// <param name="spawnPosition">point in the space of the game scene where you need to create an item</param>
        /// <returns>void</returns>
        public void AddItem(BaseItem itemInfo, Transform srcTransform) {
            
            // Initialize item physic
            var itemBox = new GameObject("ItemBox");
            var rig = itemBox.AddComponent<Rigidbody>();
            // slowing down the fall of an object for smoothness
            // and turning off rotation
            rig.drag = 1;
            rig.freezeRotation = true;
            var collider = itemBox.AddComponent<BoxCollider>();
            // moving the object collider to the bottom
            // and removing the height
            collider.center = new Vector3(0, -1.5f, 0);
            collider.size = new Vector3(1, 0, 1);
            itemBox.layer = 10;
            itemBox.transform.position = srcTransform.position;
            // Initialize item object
            if (itemInfo.type == Enums.ItemType.Block) {
                //Debug.Log(resource.Blocks.FirstOrDefault(t => t.BlockId.Equals(0)).BlockSlug);
                var blockInfo = resource.Blocks.FirstOrDefault(t => t.BlockInfo.slug.ToLower().Equals(itemInfo.slug.ToLower()));
                var itemInstance = Object.Instantiate(BlockTypeManager.Instance.GetBlockTypeByName(blockInfo.BlockTypeName.ToString()));
                
                itemInstance.GetComponent<Renderer>().material =
                    BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
                
                var blockTexture = new Texture2D(48, 48, TextureFormat.RGBA32, false);
                Debug.Log(blockInfo.BlockTexturePath);
                blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
                blockTexture.filterMode = FilterMode.Point;
                itemInstance.GetComponent<Renderer>().material.SetTexture("_BaseMap", blockTexture);

                var pickup = itemInstance.AddComponent<ItemPickup>();
                // set pick up radius
                // and add item information into item
                pickup.pickUpRadius = .7f;
                pickup.item = itemInfo;
                
                var animator = itemInstance.AddComponent<Animator>();
                animator.runtimeAnimatorController = itemAnimatorController;
                animator.applyRootMotion = true;

                // set item position
                // and set item as child for item physic
                itemInstance.transform.position = new Vector3(srcTransform.position.x, srcTransform.position.y + .5f, srcTransform.position.z);
                itemInstance.transform.SetParent(itemBox.transform);
            }
            
            // set position for item physic
            itemBox.transform.localScale = new Vector3(.3f, .3f, .3f);
            Physics.IgnoreLayerCollision(8, 10);
            // setting the direction of movement for an object
            rig.velocity = srcTransform.forward * 10;
        }

        /// <summary>
        /// adds an object to the game scene that is a reduced copy of the original object
        /// </summary>
        /// <param name="blockDto">block data</param>
        /// <returns>void</returns>
        public void AddItem(BlockDto blockDto) {
            
            var itemBox = new GameObject("ItemBox");
            var rig = itemBox.AddComponent<Rigidbody>();
            rig.drag = 1;
            rig.freezeRotation = true;
            var collider = itemBox.AddComponent<BoxCollider>();
            collider.center = new Vector3(0, -1.5f, 0);
            collider.size = new Vector3(1, 0, 1);
            itemBox.transform.position = blockDto.Position;  
            try
            {
                var resources = ResourcePackStorageProvider.Instance.LoadResourcePack();
                var blockInfo = resources.Blocks.FirstOrDefault(t => t.BlockId.Equals(blockDto.BlockId));
                var spawnedBlock = Instantiate(
                    BlockTypeManager.Instance.GetBlockTypeByName($"{blockInfo.BlockTypeName}"),
                    new Vector3(blockDto.Position.x, blockDto.Position.y + .5f, blockDto.Position.z),
                    Quaternion.Euler(new Vector3(-90, 0, 0))
                );
                spawnedBlock.name = blockInfo.BlockName;
                BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
                var blockTexture = new Texture2D(16, 16, TextureFormat.RGBA32, false);
                blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
                blockTexture.filterMode = FilterMode.Point;
                spawnedBlock.GetComponent<Renderer>().material.SetTexture("_BaseMap", blockTexture);

                #region NOT_IMPLEMENTED

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

                #endregion

                var item = new InventorySystem.Items.Block
                {
                    amount = 1, 
                    gravity = false,
                    luminosity = false,
                    type = Enums.ItemType.Block,
                    id = blockInfo.BlockId,
                    name = blockInfo.BlockName, 
                    slug = blockInfo.BlockInfo.slug
                }; 
                spawnedBlock.AddComponent<Item>().item = (BaseItem)item;

                var pickup = spawnedBlock.AddComponent<ItemPickup>();
                pickup.item = item;
                pickup.item1 = new UIItem{ 
                    amount = item.amount,
                    durability = 0,  
                    name = item.name,
                    icon = Sprite.Create(
                        spawnedBlock.GetComponent<Renderer>().material.mainTexture as Texture2D, 
                        new Rect(0, 0, 30, 30), 
                        new Vector2(0, 0)
                    )
                };
                // set pick up radius
                // and add item information into item
                pickup.pickUpRadius = .7f;
                pickup.pickupDelay = 2;
                pickup.item = blockInfo.BlockInfo;
                
                var animator = spawnedBlock.AddComponent<Animator>();
                animator.runtimeAnimatorController = itemAnimatorController;
                animator.applyRootMotion = true;
                spawnedBlock.transform.SetParent(itemBox.transform);

                itemBox.transform.localScale = new Vector3(.3f, .3f, .3f);
                  
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                throw;
            }
       
        }

        protected byte[] GetTextureBytes(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }
        #endregion
    }
}
