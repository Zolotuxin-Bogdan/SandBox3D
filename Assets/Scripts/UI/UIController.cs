using System;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIController: MonoBehaviour
    {
        public GameObject settings;
        
        //Unity Start Message
        void Start()
        {
            settings.GetComponent<SettingsController>().AddListener(SettingsListener);
        }
        //Unity Update Message
        void Update()
        {

        }
        
        void SettingsListener(SettingsEvent @event)
        {
            switch (@event)
            {
                case SettingsEvent.TexturePackClicked:
                    break;
                case SettingsEvent.SnooperSettingsClicked:
                    break;
                case SettingsEvent.LanguageClicked:
                    break;
                case SettingsEvent.MultiplayerSettingsClicked:
                    break;
                case SettingsEvent.VideoSettingsClicked:
                    break;
                case SettingsEvent.ControlsClicked:
                    break;
                case SettingsEvent.DoneClicked:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
    }
}