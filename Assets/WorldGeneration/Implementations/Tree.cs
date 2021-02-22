using System.Collections.Generic;
using Assets.Scripts.DTO;
using UnityEngine;

namespace Assets.WorldGeneration.Implementations
{
    public class Tree
    {
        public virtual List<BlockDto> GenerateDtoList(Vector3 position)
        {
            Debug.Log("Generate Tree");
            return new List<BlockDto>();
        }
    }
}