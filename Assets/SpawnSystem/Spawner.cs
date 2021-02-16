using System.Collections.Generic;
using UnityEngine;


namespace Assets.SpawnSystem
{
    public class Spawner : MonoBehaviour 
    {
        [Header("Spawn Controls")]
        public Vector3 spawnPoint;
        public GameObject[] Prefabs;

        public GameObject[] SpawnObject()
        {
            var createdObjects = new List<GameObject>();

            foreach (var prefab in Prefabs)
            {
                var obj = Instantiate(prefab, spawnPoint, Quaternion.identity);
                obj.name = prefab.name;
                createdObjects.Add(obj);
            }

            return createdObjects.ToArray();
        }
    }
}