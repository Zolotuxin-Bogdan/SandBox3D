using UnityEngine;
using UnityEditor;
using Assets.StorageSystem.StorageProviders;
using Assets.Scripts;

namespace Assets.Editor
{
    public class Managers: ScriptableWizard {

        [Tooltip("Resource Pack Storage Provider")]
        [SerializeField] bool rPStorageProvider;

        [Tooltip("Resource Pack Manager")]
        [SerializeField] bool rPManager;

        [Tooltip("Block Type Manager")]
        [SerializeField] bool bTManager;

        [Tooltip("Block Material Manager")]
        [SerializeField] bool bMManager;

        [SerializeField] bool sceneEditor;
        [SerializeField] bool inputSystem;
        
        [Tooltip("Player States Manager")]
        [SerializeField] bool pSManager;


        [MenuItem("SandBox3D/ToolsManager")]
        private static void MenuEntryCall() {
            DisplayWizard<Managers>("Select Managers");
        }

        private void OnWizardCreate() {
            GameObject go = new GameObject("ToolsObject");
            if (rPStorageProvider)
                go.AddComponent<ResourcePackStorageProvider>();
            if (rPManager)
                go.AddComponent<ResourcePackManager>();
            if (bTManager)
                go.AddComponent<BlockTypeManager>();
            if (bMManager)
                go.AddComponent<BlockMaterialManager>();
            if (sceneEditor)
                go.AddComponent<SceneEditor>();
            if (pSManager)
                go.AddComponent<PlayerStatesManager>();
            if (inputSystem)
                go.AddComponent<InputSystem>();
        }

        private void OnWizardUpdate() {
            helpString = "Create gameobject with selected tools";
        }
    }
}