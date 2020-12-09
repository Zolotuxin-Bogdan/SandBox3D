using UnityEngine;


namespace Assets.SpawnSystem
{
    public class Spawner : MonoBehaviour 
    {
        [Header("Spawn Controls")]
        public Vector3 spawnPoint;
        public GameObject objectPrefab;

        private void Start() 
        {
            SpawnObject();
        }
        private void SpawnObject()
        {
            Instantiate(objectPrefab, spawnPoint, Quaternion.identity);
        }
    }
}