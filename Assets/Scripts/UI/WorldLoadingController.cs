using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using Assets.Scripts.Tools_and_Managers;
using Assets.SpawnSystem;
using Assets.WorldGeneration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WorldLoadingController : MonoBehaviour, ILocalization
    {

        public Slider LoadingProgress;
        public TextMeshProUGUI LoadingProgressText;
        public TextMeshProUGUI LoadingLabel;
        public GameObject Player;
        public GameObject PlayerCamera;
        public GameObject SceneCamera;


        public static WorldLoadingController Instance;

        private void Awake()
        {
            Instance = this;
        }


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

        public void SetLocalization()
        {
            LoadingLabel.text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.loading.ToString());
        }
    }
}
