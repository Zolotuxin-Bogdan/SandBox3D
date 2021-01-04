using System.Collections;
using Assets.WorldGeneration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class WorldLoadingController : MonoBehaviour
    {
        public TextMeshProUGUI loadState;
        public string worldName;

        string[] states = 
        {
            "Load World",
            "Build Terrain"
        };

        void Start()
        {
            StartCoroutine(LoadWorld());
        }

        private IEnumerator LoadWorld()
        {
            while (true)
            {
                loadState.text = states[0];
                //worldloader.LoadWorld(worldName);
                loadState.text = states[1];
                gameObject.AddComponent<WorldGenerator>().GenerateWorld();
                action.Invoke();
            }
        }

        protected UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}
