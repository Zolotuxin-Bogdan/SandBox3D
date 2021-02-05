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

        void Start()
        {
            StartCoroutine(LoadWorld());
        }

        private IEnumerator LoadWorld()
        {
            loadState.text = "Loading world";

            while (true)
            {

            }
        }

        protected UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}
