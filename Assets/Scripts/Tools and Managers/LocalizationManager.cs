using System.Collections.Generic;
using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class LocalizationManager : MonoBehaviour
    {
        private void Start()
        {
            UpdateLocalization();
        }

        public static void UpdateLocalization()
        {
            Localizer.RegisterController(MenuController.Instance);
            Localizer.RegisterController(ControlsController.Instance);
            Localizer.RegisterController(CreateWorldController.Instance);
            Localizer.RegisterController(LanguageController.Instance);
            Localizer.RegisterController(MultiplayerMenuController.Instance);
            Localizer.RegisterController(MultiplayerSettingsController.Instance);
            Localizer.RegisterController(RenameWorldController.Instance);
            Localizer.RegisterController(SettingsController.Instance);
            Localizer.RegisterController(SingleplayerMenuController.Instance);
            Localizer.RegisterController(TexturePackController.Instance);
            Localizer.RegisterController(VideoSettingsController.Instance);
            Localizer.RegisterController(WorldLoadingController.Instance);
        }
    }
}