using System;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.UI.Handlers
{
    public class SettingsHandler: MonoBehaviour
    {
        public GameObject Settings;
        public GameObject Controls;
        public GameObject SnooperSettings;
        public GameObject TexturePack;
        public GameObject Language;
        public GameObject MultiplayerSettings;
        public GameObject VideoSettings;
        public GameObject Background;
        public SettingsManager SettingsManager;

        SettingsController settingsController;
        ControlsController controlsController;
        SnooperSettingsController snooperSettingsController;
        TexturePackController texturePackController;
        LanguageController languageController;
        VideoSettingsController videoSettingsController;
        //Unity Start Message
        void Start()
        {
            settingsController = Settings.GetComponent<SettingsController>();//
            controlsController = Controls.GetComponent<ControlsController>();//
            snooperSettingsController = SnooperSettings.GetComponent<SnooperSettingsController>();//
            texturePackController = TexturePack.GetComponent<TexturePackController>();//
            languageController = Language.GetComponent<LanguageController>();//
            videoSettingsController = VideoSettings.GetComponent<VideoSettingsController>();//

            settingsController.AddListener(SettingsControllerHandler);
            controlsController.AddListener(ControlsControllerHandler);
            snooperSettingsController.AddListener(SnooperSettingsControllerHandler);
            texturePackController.AddListener(TexturePackControllerHandler);
            languageController.AddListener(LanguageControllerHandler);
            videoSettingsController.AddListener(VideoSettingsControllerHandler);

            Settings.SetActive(false);
            Background.SetActive(false);
            Controls.SetActive(false);
            SnooperSettings.SetActive(false);
            TexturePack.SetActive(false);
            Language.SetActive(false);
            MultiplayerSettings.SetActive(false);
            VideoSettings.SetActive(false);
        }

        void SettingsControllerHandler(SettingsEvent @event)
        {
            switch (@event)
            {
                case SettingsEvent.TexturePackClicked:
                    Settings.SetActive(false);
                    TexturePack.SetActive(true);
                    break;
                case SettingsEvent.SnooperSettingsClicked:
                    Settings.SetActive(false);
                    SnooperSettings.SetActive(true);
                    break;
                case SettingsEvent.LanguageClicked:
                    Settings.SetActive(false);
                    Language.SetActive(true);
                    break;
                case SettingsEvent.MultiplayerSettingsClicked:
                    Settings.SetActive(false);
                    MultiplayerSettings.SetActive(true);
                    break;
                case SettingsEvent.VideoSettingsClicked:
                    Settings.SetActive(false);
                    VideoSettings.SetActive(true);
                    break;
                case SettingsEvent.ControlsClicked:
                    Settings.SetActive(false);
                    Controls.SetActive(true);
                    break;
                case SettingsEvent.DoneClicked:
                    Settings.SetActive(false);
                    SettingsManager.SaveSettings();
                    Background.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        
        private void ControlsControllerHandler()
        {
            Settings.SetActive(true);
            Controls.SetActive(false);
        }

        private void SnooperSettingsControllerHandler()
        {
            Settings.SetActive(true);
            SnooperSettings.SetActive(false);
        }

        private void TexturePackControllerHandler()
        {
            Settings.SetActive(true);
            TexturePack.SetActive(false);
        }

        private void LanguageControllerHandler()
        {
            Settings.SetActive(true);
            Language.SetActive(false);
        }

        private void VideoSettingsControllerHandler()
        {
            Settings.SetActive(true);
            VideoSettings.SetActive(false);
        }
    }
}