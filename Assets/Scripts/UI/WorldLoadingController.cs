using System.Collections;
using Assets.Scripts.Enums;
using Assets.WorldGeneration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class WorldLoadingController : MonoBehaviour
    {
        public void LoadWorld(WorldGenerationType generationType){
            BlockInstanceManager.Instance.OnWorldGenerated += () => {action.Invoke();};
            BlockInstanceManager.Instance.GenerateWorld(WorldGeneratorFactory.GetWorldGenerator(generationType));
        }

        protected UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}
