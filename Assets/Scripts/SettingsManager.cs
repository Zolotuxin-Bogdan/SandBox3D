using Assets.Scripts.Enums;
using Assets.Scripts.UserSettings;
using UnityEngine;

namespace Assets.Scripts
{
    public class SettingsManager: MonoBehaviour
    {
        GameSettings settings;
        private void Start() 
        {
            settings = new GameSettings();
        }
        public GameSettings GetSettings()
        {
            return settings;
        }
    }
}