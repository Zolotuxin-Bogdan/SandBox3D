using Assets.Scripts.UserSettings;
using UnityEngine;

namespace Assets.Scripts
{
    public class SettingsManager: MonoBehaviour
    {
        [Header("Save/Load Controls")]
        public string relativePath = "\\config\\";
        
        string file;
        GameSettings settings;
        Storage settingsStorage;
        private void Awake() 
        {
            file = "settings.json";
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