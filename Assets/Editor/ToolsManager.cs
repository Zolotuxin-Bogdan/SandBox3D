using System.Linq;
using UnityEngine;
using UnityEditor;
using Assets.StorageSystem.StorageProviders;
using Assets.Scripts;

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
        
        [Tooltip("Player States Manager")]
        [SerializeField] bool pSManager;


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
                go.AddComponent<SceneEditor>();

            if (pSManager)
                go.AddComponent<PlayerStatesManager>();

            if (inputSystem)
                go.AddComponent<InputSystem.InputSystem>();
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
                        if (gameObject.GetComponent<SceneEditor>() == null)
                            gameObject.AddComponent<SceneEditor>();

                    if (pSManager)
                        if (gameObject.GetComponent<PlayerStatesManager>() == null)
                            gameObject.AddComponent<PlayerStatesManager>();

                    if (inputSystem)
                        if (gameObject.GetComponent<InputSystem.InputSystem>() == null)
                            gameObject.AddComponent<InputSystem.InputSystem>();
                } else
                {
                    EditorUtility.DisplayDialog("Warning", "This GameObject not found on scene", "Close");
                }
        }
    }
}