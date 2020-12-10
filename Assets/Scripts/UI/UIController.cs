using System;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIController: MonoBehaviour
    {
        public GameObject settings;
        public GameObject controls;
        public GameObject snooperSettings;
        public GameObject texturePack;
        public GameObject language;
        public GameObject multiplayerSettings;
        public GameObject videoSettings;
        
        SettingsController settingsController;
        ControlsController controlsController;
        SnooperSettingsController snooperSettingsController;
        TexturePackController texturePackController;
        LanguageController languageController;
        MultiplayerSettingsController multiplayerSettingsController;
        VideoSettingsController videoSettingsController;

        //Unity Start Message
        void Start()
        {
            settingsController = GetComponentInChildren<SettingsController>();//
            controlsController = GetComponentInChildren<ControlsController>();//
            snooperSettingsController = GetComponentInChildren<SnooperSettingsController>();//
            texturePackController = GetComponentInChildren<TexturePackController>();//
            languageController = GetComponentInChildren<LanguageController>();//
            multiplayerSettingsController = GetComponentInChildren<MultiplayerSettingsController>();//
            videoSettingsController = GetComponentInChildren<VideoSettingsController>();//

            settingsController.AddListener(SettingsListener);
            controlsController.AddListener(ControlsListener);
            snooperSettingsController.AddListener(SnooperSettingsListener);
            texturePackController.AddListener(TexturePackListener);
            languageController.AddListener(LanguageListener);
            multiplayerSettingsController.AddListener(MultiplayerSettingsListener);
            videoSettingsController.AddListener(VideoSettingsListener);

            controls.SetActive(false);
            snooperSettings.SetActive(false);
            texturePack.SetActive(false);
            language.SetActive(false);
            multiplayerSettings.SetActive(false);
            videoSettings.SetActive(false);
        }        
        void SettingsListener(SettingsEvent @event)
        {
            switch (@event)
            {
                case SettingsEvent.TexturePackClicked:
                    settings.SetActive(false);
                    texturePack.SetActive(true);
                    break;
                case SettingsEvent.SnooperSettingsClicked:
                    settings.SetActive(false);
                    snooperSettings.SetActive(true);
                    break;
                case SettingsEvent.LanguageClicked:
                    settings.SetActive(false);
                    language.SetActive(true);
                    break;
                case SettingsEvent.MultiplayerSettingsClicked:
                    settings.SetActive(false);
                    multiplayerSettings.SetActive(true);
                    break;
                case SettingsEvent.VideoSettingsClicked:
                    settings.SetActive(false);
                    videoSettings.SetActive(true);
                    break;
                case SettingsEvent.ControlsClicked:
                    settings.SetActive(false);
                    controls.SetActive(true);
                    break;
                case SettingsEvent.DoneClicked:
                    settings.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        
        private void ControlsListener()
        {
            settings.SetActive(true);
            controls.SetActive(false);
        }

        private void SnooperSettingsListener()
        {
            settings.SetActive(true);
            snooperSettings.SetActive(false);
        }

        private void TexturePackListener()
        {
            settings.SetActive(true);
            texturePack.SetActive(false);
        }

        private void LanguageListener()
        {
            settings.SetActive(true);
            language.SetActive(false);
        }

        private void MultiplayerSettingsListener()
        {
            settings.SetActive(true);
            multiplayerSettings.SetActive(false);
        }

        private void VideoSettingsListener()
        {
            settings.SetActive(true);
            videoSettings.SetActive(false);
        }
    }
}