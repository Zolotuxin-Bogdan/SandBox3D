using Assets.InventorySystem;
using Assets.Scripts.DTO;
using Assets.StorageSystem.StorageProviders;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Obsolete("SceneEditor is deprecated.")]
    public class SceneEditor
    {

        MeshProvider meshLoader;
        public SceneEditor()
        {
            meshLoader = new MeshProvider();
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
            throw new System.NotImplementedException();
            // try
            // {
            //     var resources = ResourcePackStorageProvider.Instance.LoadResourcePack();
            //     var blockInfo = resources.Blocks[blockDto.BlockId];
            //     var spawnedBlock = Object.Instantiate(BlockTypeManager.Instance.GetBlockTypeByName($"{blockInfo.BlockTypeName}"), blockDto.Position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            //     spawnedBlock.name = blockInfo.BlockName;
            //     BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
            //     var blockTexture = new Texture2D(16, 16, TextureFormat.RGBA32, false);
            //     blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
            //     blockTexture.filterMode = FilterMode.Point;
            //     spawnedBlock.GetComponent<Renderer>().material.SetTexture("_MainTex", blockTexture);

            //     var item = new Assets.InventorySystem.Items.Block{
            //         count = 1, 
            //         isContainer = false, 
            //         descriptiom = $"{blockInfo.BlockProperties}", 
            //         name = blockInfo.BlockName, 
            //         slug = $"item.block.{blockInfo.BlockName}_{blockInfo.BlockTypeName}:{blockInfo.BlockId}"
            //     }; 
            //     spawnedBlock.AddComponent<Item>().item = (BaseItem)item;
            
            //     return true;    
            // }
            // catch (System.Exception e)
            // {
            //     Debug.LogError(e);
            //     return false;
            // }
       
        }

        protected byte[] GetTextureBytes(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }
    }
}
