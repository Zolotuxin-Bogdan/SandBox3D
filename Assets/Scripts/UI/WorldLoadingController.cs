﻿using System.Collections;
using System.IO;
using Assets.Scripts.Enums;
using Assets.SpawnSystem;
using Assets.WorldGeneration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WorldLoadingController : MonoBehaviour
    {

        public Slider LoadingProgress;
        public TextMeshProUGUI LoadingProgressText;
        public GameObject Player;
        public GameObject PlayerCamera;
        public GameObject SceneCamera;

        public void LoadWorld(WorldGenerationType generationType)
        {
            BlockInstanceManager.Instance.LoadingProgress += OnLoadingProgress;
            BlockInstanceManager.Instance.OnWorldGenerated += OnWorldGenerated;
            BlockInstanceManager.Instance.GenerateWorld(WorldGeneratorFactory.GetWorldGenerator(generationType));
        }

        private void OnWorldGenerated()
        {
            action.Invoke();
            var obj = new GameObject("Global Spawner");
            var PlayerSpawner = obj.AddComponent<Spawner>();

            PlayerSpawner.spawnPoint = new Vector3(0, 50, 0);
            PlayerSpawner.Prefabs = new [] {Player, PlayerCamera};
            var SpawnedObjects = PlayerSpawner.SpawnObject();
            SpawnedObjects[0].GetComponent<PlayerController>().FirstPersonCam = SpawnedObjects[1].GetComponent<Camera>();
            SpawnedObjects[1].GetComponent<MouseLook>().settings = SettingsManager.Instance;
            SceneCamera.SetActive(false);
        }

        private void OnLoadingProgress(int loadingProgress)
        {
            LoadingProgress.value = loadingProgress;
            LoadingProgressText.text = $"{loadingProgress}%";
        }

        protected UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}
