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
                
        //Unity Start Message
        void Start()
        {
            settings.GetComponent<SettingsController>().AddListener(SettingsListener);
            controls.GetComponent<ControlsController>().AddListener(ControlsListener);
            snooperSettings.GetComponent<SnooperSettingsController>().AddListener(SnooperSettingsListener);
            texturePack.GetComponent<TexturePackController>().AddListener(TexturePackListener);
            language.GetComponent<LanguageController>().AddListener(LanguageListener);
            multiplayerSettings.GetComponent<MultiplayerSettingsController>().AddListener(MultiplayerSettingsListener);
            videoSettings.GetComponent<VideoSettingsController>().AddListener(VideoSettingsListener);
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
            throw new NotImplementedException();
        }

        private void SnooperSettingsListener()
        {
            throw new NotImplementedException();
        }

        private void TexturePackListener()
        {
            throw new NotImplementedException();
        }

        private void LanguageListener()
        {
            throw new NotImplementedException();
        }

        private void MultiplayerSettingsListener()
        {
            throw new NotImplementedException();
        }

        private void VideoSettingsListener()
        {
            throw new NotImplementedException();
        }
    }
}