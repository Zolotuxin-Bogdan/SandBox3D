using System.Collections;
using Assets.Scripts.Enums;
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

        public void LoadWorld(WorldGenerationType generationType){
            BlockInstanceManager.Instance.LoadingProgress += OnLoadingProgress;
            BlockInstanceManager.Instance.OnWorldGenerated += OnWorldGenerated;
            BlockInstanceManager.Instance.GenerateWorld(WorldGeneratorFactory.GetWorldGenerator(generationType));
        }

        private void OnWorldGenerated()
        {
            action.Invoke();
            BlockInstanceManager.Instance.LoadingProgress -= OnLoadingProgress;
            BlockInstanceManager.Instance.OnWorldGenerated -= OnWorldGenerated;
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
