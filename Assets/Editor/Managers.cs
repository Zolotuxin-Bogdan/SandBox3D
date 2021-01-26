using UnityEngine;
using UnityEditor;
using Assets.StorageSystem.StorageProviders;
using Assets.Scripts;

namespace Assets.Editor
{
    public class Managers: ScriptableWizard {

        [SerializeField] bool resourcePackStorageProvider;
        [SerializeField] bool blockTypeManager;
        [SerializeField] bool blockMaterialManager;
        [SerializeField] bool resourcePackManager;
        [SerializeField] bool sceneEditor;


        [MenuItem("SandBox3D/ToolsManager")]
        private static void MenuEntryCall() {
            DisplayWizard<Managers>("Select Managers");
        }

        private void OnWizardCreate() {
            GameObject go = new GameObject("Tools");
            if (resourcePackStorageProvider)
                go.AddComponent<ResourcePackStorageProvider>();
            if (resourcePackManager)
                go.AddComponent<ResourcePackManager>();
            if (blockTypeManager)
                go.AddComponent<BlockTypeManager>();
            if (blockMaterialManager)
                go.AddComponent<BlockMaterialManager>();
            if (sceneEditor)
                go.AddComponent<SceneEditor>();
        }
    }
}