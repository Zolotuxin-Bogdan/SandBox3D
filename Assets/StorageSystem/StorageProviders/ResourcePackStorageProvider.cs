﻿using System.IO;
using Assets.Scripts;
using Assets.Scripts.Data_Models;
using Assets.Scripts.Tools_and_Managers;
using UnityEngine;

namespace Assets.StorageSystem.StorageProviders
{
    public class ResourcePackStorageProvider : MonoBehaviour
    {
        public static ResourcePackStorageProvider Instance { get; private set; }

        public string ResourcePackPath;

        private Storage _storage = new Storage();

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

            ResourcePackPath = Directory.GetCurrentDirectory() + "\\ResourcePacks" + "\\DefaultResourcePack.rpk";
        }

        public void CreateResourcePack()
        {
            var resourcePack = ResourcePackManager.Instance.CreateResourcePack();
            _storage.SaveData(resourcePack, ResourcePackPath);
        }

        public ResourcePack LoadResourcePack()
        {
            TryLoadResourcePack(out var resourcePack);
            return resourcePack;
        }

        public bool TryLoadResourcePack(out ResourcePack result)
        {
            try
            {
                result = _storage.LoadData<ResourcePack>(ResourcePackPath);
                return true;
            }
            catch (FileNotFoundException)
            {
                result = null;
                return false;
            }
        }
    }
}
