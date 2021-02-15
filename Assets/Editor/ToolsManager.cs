using System.Linq;
using UnityEngine;
using UnityEditor;
using Assets.StorageSystem.StorageProviders;
using Assets.Scripts;
using Assets.WorldGeneration;

namespace Assets.Editor
{
    public class ToolsManager: ScriptableWizard
    {
        [SerializeField] string objectName = "ToolsObject";
        
        [Header("\n")]
        
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
        [SerializeField] bool settingsManager;
        
        [Tooltip("Player States Manager")]
        [SerializeField] bool pSManager;

        [Tooltip("Block Instance Manager")]
        [SerializeField] bool bIManager;

        [MenuItem("SandBox3D/ToolsManager")]
        private static void MenuEntryCall() {
            DisplayWizard<ToolsManager>("Select Managers", "Create", "Update");
        }

        private void OnWizardCreate() {
            GameObject go = new GameObject(objectName);
            if (rPStorageProvider)
                go.AddComponent<ResourcePackStorageProvider>();

            if (rPManager)
                go.AddComponent<ResourcePackManager>();

            if (bTManager)
                go.AddComponent<BlockTypeManager>();

            if (bMManager)
                go.AddComponent<BlockMaterialManager>();

            if (sceneEditor)
                go.AddComponent<ItemSpawner>();

            if (pSManager)
                go.AddComponent<PlayerStatesManager>();

            if (inputSystem)
                go.AddComponent<InputSystem.InputSystem>();
            if (settingsManager)
                go.AddComponent<SettingsManager>();
            if (bIManager)
                go.AddComponent<BlockInstanceManager>();
        }

        private void OnWizardUpdate() {
            helpString = "Create gameobject with selected tools";
        }

        private void OnWizardOtherButton()
        {
            var objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            var gameObject = objects.FirstOrDefault(o => o.name == objectName);
                if (gameObject != null)
                {
                    if (rPStorageProvider)
                        if (gameObject.GetComponent<ResourcePackStorageProvider>() == null)
                            gameObject.AddComponent<ResourcePackStorageProvider>();

                    if (rPManager)
                        if (gameObject.GetComponent<ResourcePackManager>() == null)
                            gameObject.AddComponent<ResourcePackManager>();

                    if (bTManager)
                        if (gameObject.GetComponent<BlockTypeManager>() == null)
                            gameObject.AddComponent<BlockTypeManager>();

                    if (bMManager)
                        if (gameObject.GetComponent<BlockMaterialManager>() == null)
                            gameObject.AddComponent<BlockMaterialManager>();

                    if (sceneEditor)
                        if (gameObject.GetComponent<ItemSpawner>() == null)
                            gameObject.AddComponent<ItemSpawner>();

                    if (pSManager)
                        if (gameObject.GetComponent<PlayerStatesManager>() == null)
                            gameObject.AddComponent<PlayerStatesManager>();

                    if (inputSystem)
                        if (gameObject.GetComponent<InputSystem.InputSystem>() == null)
                            gameObject.AddComponent<InputSystem.InputSystem>();
                    if (settingsManager)
                        if (gameObject.GetComponent<SettingsManager>() == null)
                            gameObject.AddComponent<SettingsManager>();
                    if (bIManager)
                        if (gameObject.GetComponent<BlockInstanceManager>() == null)
                            gameObject.AddComponent<BlockInstanceManager>();
                } else
                {
                    EditorUtility.DisplayDialog("Warning", "This GameObject not found on scene", "Close");
                }
        }
    }
}