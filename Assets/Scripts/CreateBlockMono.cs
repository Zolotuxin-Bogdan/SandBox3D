using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
using Assets.WorldGeneration;
using UnityEngine;

namespace Assets.Scripts
{
    public class CreateBlockMono : MonoBehaviour
    {
        void Start()
        {
            new BlockInstanceGenerator(ResourcePackManager.Instance.CreateResourcePack()).CreateBlockInstance(new BlockDto{Position = Vector3.zero, BlockId = 7});
        }
    }
}