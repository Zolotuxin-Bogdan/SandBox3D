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

        public BlockInstanceGenerator(ResourcePack resourcePack)
        {
            _resourcePack = resourcePack;
        }
        public void CreateBlockInstance(BlockDto blockDto)
        {
            var blockInfo = _resourcePack.Blocks.FirstOrDefault(t => t.BlockId.Equals(blockDto.BlockId));
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
        }

        private byte[] GetTextureBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
