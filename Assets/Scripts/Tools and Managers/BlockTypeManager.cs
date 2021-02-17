using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class BlockTypeManager : MonoBehaviour
    {
        public static BlockTypeManager Instance { get; private set; }

        //
        // Block Types
        //
        public GameObject FullSizeBlock;

        private Dictionary<string, GameObject> _typeDictionary = new Dictionary<string, GameObject>();
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
            _typeDictionary.Add(BlockType.FullSizeBlock.ToString(), FullSizeBlock);
        }
        void Start()
        {
            
        }
        public GameObject GetBlockTypeByName(string typeName)
        {
            var isContains = _typeDictionary.ContainsKey(typeName);
            if (!isContains)
            {
                return null;
            }
            return _typeDictionary[typeName];
        }
    }
}
