﻿using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class BlockMaterialManager : MonoBehaviour
    {
        public static BlockMaterialManager Instance { get; private set; }

        //
        // Material Types
        //
        public Material FullSizeBlockMaterial;
        public Material AlphaChannelsMaterial;
        public Material TransparentMaterial;

        private Dictionary<string, Material> _materialDictionary = new Dictionary<string, Material>();
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
        void Start()
        {
            _materialDictionary.Add(MaterialType.FullSizeBlockMaterial.ToString(), FullSizeBlockMaterial);
            _materialDictionary.Add(MaterialType.AlphaChannelsMaterial.ToString(), AlphaChannelsMaterial);
            _materialDictionary.Add(MaterialType.Transparentmaterial.ToString(), TransparentMaterial);

        }
        public Material GetBlockMaterialByName(string typeName)
        {
            var isContains = _materialDictionary.ContainsKey(typeName);
            if (!isContains)
            {
                return null;
            }
            return _materialDictionary[typeName];
        }
    }
}
