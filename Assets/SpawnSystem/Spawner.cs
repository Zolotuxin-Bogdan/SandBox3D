using UnityEngine;


namespace Assets.SpawnSystem
{
    public class Spawner : MonoBehaviour 
    {
        [Header("Spawn Controls")]
        public Vector3 spawnPoint;
        public GameObject[] Prefabs;

        private void Start() 
        {
            SpawnObject();
        }
        private void SpawnObject()
        {
            foreach (var prefab in Prefabs)
            {
                Instantiate(prefab, spawnPoint, Quaternion.identity);
            }
        }
    }
}