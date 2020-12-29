using UnityEditor;
using UnityEngine;
namespace Assets.SpawnSystem
{
    public class CreateSpawnerObject : MonoBehaviour {
        [MenuItem("GameObject/Spawner")]
        [ContextMenu("Spawner")]
        static void CreateSpawner(){
            GameObject g_Obj = new GameObject("Spawner");
            g_Obj.AddComponent<Spawner>();
        }
    }
}