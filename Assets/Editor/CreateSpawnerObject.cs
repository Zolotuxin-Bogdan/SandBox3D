using Assets.SpawnSystem;
using UnityEditor;
using UnityEngine;
namespace Assets.Editor
{
    public class CreateSpawnerObject : MonoBehaviour {
        [MenuItem("GameObject/Spawner", false, 11)]
        [ContextMenu("Spawner", false)]
        static void CreateSpawner(){
            GameObject g_Obj = new GameObject("Spawner");
            g_Obj.AddComponent<Spawner>();
        }
    }
}