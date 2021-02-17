using Assets.Scripts.UserSettings;
using Assets.StorageSystem;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class SettingsManager: MonoBehaviour
    {
        [Header("Settings Controls")]
        public string relativePath = "\\config\\";
        [SerializeField] string file = "settings.json";
        [SerializeField] GameSettings settings;
        [SerializeField] Storage settingsStorage;

        public static SettingsManager Instance;
        private void Awake()
        {
            Instance = this;
            settingsStorage = new Storage();
            TryLoadSettings();
        }
        public GameSettings GetSettings()
        {
            return settings;
        }
        public void SaveSettings()
        {
            settingsStorage.SaveData<GameSettings>(settings, Application.dataPath + relativePath + file);
        }
        public void TryLoadSettings()
        {
            try
            {
                settings = settingsStorage.LoadData<GameSettings>(Application.dataPath + relativePath + file);
                print("settings loaded");
            }
            catch (System.Exception e)
            {
                settings = new GameSettings();
                print("failed to load settings, create default instance");
                Debug.LogError(e);
                throw;
            }
        }
    }
}