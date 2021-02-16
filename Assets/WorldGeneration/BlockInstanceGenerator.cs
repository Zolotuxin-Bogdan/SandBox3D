using System.IO;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
using UnityEngine;

namespace Assets.WorldGeneration
{
    public class BlockInstanceGenerator
    {
        private readonly ResourcePack _resourcePack;
        private GameObject _world;

        public BlockInstanceGenerator(ResourcePack resourcePack)
        {
            _resourcePack = resourcePack;
            _world = new GameObject("World");
            _world.AddComponent<MeshFilter>();
            _world.AddComponent<MeshRenderer>();

        }
        public void CreateBlockInstance(BlockDto blockDto)
        {
            Debug.Log($"[DEBUG]: {blockDto}");
            Debug.Log($"[DEBUG]: {_resourcePack}");
            var blockInfo = _resourcePack.Blocks.FirstOrDefault(t => t.BlockId.Equals(blockDto.BlockId));
            Debug.Log($"[DEBUG]: {blockInfo}");
            var createdBlock = Object.Instantiate(BlockTypeManager.Instance.GetBlockTypeByName(blockInfo.BlockTypeName.ToString()), blockDto.Position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            createdBlock.name = blockInfo.BlockName;
            createdBlock.AddComponent<BoxCollider>();
            createdBlock.AddComponent<BlockInstance>().SetDefaultValues(blockInfo);
            createdBlock.GetComponent<Renderer>().material =
                BlockMaterialManager.Instance.GetBlockMaterialByName(blockInfo.BlockMaterialType.ToString());
            var blockTexture = new Texture2D(48, 48, TextureFormat.RGBA32, false);
            blockTexture.LoadImage(GetTextureBytes(blockInfo.BlockTexturePath));
            blockTexture.filterMode = FilterMode.Point;
            createdBlock.GetComponent<Renderer>().material.SetTexture("_BaseMap", blockTexture);
            createdBlock.transform.parent = _world.transform;
        }

        public void Combine()
        {
            CombineMeshes(_world);
        }

        private void CombineMeshes(GameObject world)
        {
            MeshFilter[] meshFilters = world.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);
                i++;
            }

            var meshFilter = world.transform.GetComponent<MeshFilter>();
            meshFilter.mesh = new Mesh();
            meshFilter.mesh.CombineMeshes(combine);
            world.transform.gameObject.SetActive(true);
        }

        private byte[] GetTextureBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
