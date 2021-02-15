using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SettingsController: MonoBehaviour
    {
        Difficulty gameDifficulty;
        
        public SettingsManager settingsManager;
        //////////////////////////////////////////////
        ///////////////Simple buttons////////////////
        [Header("Settings buttons")]
        public Button DoneButton;
        public Button TexturePackButton;
        public Button SnooperSettingsButton;
        public Button LanguageButton;
        public Button MultiplayerSettingsButton;
        public Button VideoSettingsButton;
        public Button ControlsButton;

        //////////////////////////////////////////////
        ///////////////Switch buttons////////////////
        public Button SwitchTouchscreenModeButton;
        public Button SwitchMouseInvertButton;
        public Button SwitchDifficultyButton;
        //////////////////////////////////////////////
        ///////////////////Sliders///////////////////
        [Header("Settings Sliders")]
        public Slider MusicVolumeSlider;
        public Slider SoundVolumeSlider;
        public Slider SensitivityValueSlider;
        public Slider FovValueSlider;
        //////////////////////////////////////////////
        ////////////////Unity Messages///////////////
        void Start() {
            DoneButton.onClick.AddListener(Submit);
            TexturePackButton.onClick.AddListener(ShowTexturePackWin);
            SnooperSettingsButton.onClick.AddListener(ShowSnooperSettingsWin);
            LanguageButton.onClick.AddListener(ShowLanguageWin);
            MultiplayerSettingsButton.onClick.AddListener(ShowMultiplayerSettingsWin);
            VideoSettingsButton.onClick.AddListener(ShowVideoSettingsWin);
            ControlsButton.onClick.AddListener(ShowControlsWin);

            SwitchTouchscreenModeButton.onClick.AddListener(SwitchTouchscreenModeValue);
            SwitchMouseInvertButton.onClick.AddListener(SwitchMouseInvertValue);
            SwitchDifficultyButton.onClick.AddListener(SwitchDifficulty);
            
            MusicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
            SoundVolumeSlider.onValueChanged.AddListener(UpdateSoundVolume);
            SensitivityValueSlider.onValueChanged.AddListener(UpdateSensitivityValue);
            FovValueSlider.onValueChanged.AddListener(UpdateFovValue);
        }
        //////////////////////////////////////////////
        ////////////////////Events///////////////////
        void Submit()
        {
            _action.Invoke(SettingsEvent.DoneClicked);
        }

        void ShowTexturePackWin()
        {
            _action.Invoke(SettingsEvent.TexturePackClicked);
        }

        void ShowSnooperSettingsWin()
        {
            _action.Invoke(SettingsEvent.SnooperSettingsClicked);
        }

        void ShowLanguageWin()
        {
            _action.Invoke(SettingsEvent.LanguageClicked);
        }

        void ShowMultiplayerSettingsWin()
        {
            _action.Invoke(SettingsEvent.MultiplayerSettingsClicked);
        }

        void ShowVideoSettingsWin()
        {
            _action.Invoke(SettingsEvent.VideoSettingsClicked);
        }

        void ShowControlsWin()
        {
            _action.Invoke(SettingsEvent.ControlsClicked);
        }

        void SwitchTouchscreenModeValue()
        {
            var text = SwitchTouchscreenModeButton.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Touchscreen Mode: ON";
                settingsManager.GetSettings().touchscreenMode = true;
                
            }
            else if (text.Contains("ON"))
            {
                text = "Touchscreen Mode: OFF";
                settingsManager.GetSettings().touchscreenMode = false;
            }
            SwitchTouchscreenModeButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void SwitchMouseInvertValue()
        {
            var text = SwitchMouseInvertButton.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Invert Mouse: ON";
            settingsManager.GetSettings().invertMouse = true;
            }
            else if (text.Contains("ON"))
            {
                text = "Invert Mouse: OFF";
                settingsManager.GetSettings().invertMouse = false;
            }
            SwitchMouseInvertButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void SwitchDifficulty()
        {
            var text = SwitchDifficultyButton.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("Easy"))
            {
                text = $"Difficulty: {Difficulty.Normal}";
                settingsManager.GetSettings().difficulty = Difficulty.Normal;
            }
            else if (text.Contains("Normal"))
            {
                text = $"Difficulty: {Difficulty.Hard}";
                settingsManager.GetSettings().difficulty = Difficulty.Hard;
            }
            else if (text.Contains("Hard"))
            {
                text = $"Difficulty: {Difficulty.Peaceful}";
                settingsManager.GetSettings().difficulty = Difficulty.Peaceful;
            }
            else if (text.Contains("Peaceful"))
            {
                text = $"Difficulty: {Difficulty.Easy}";
                settingsManager.GetSettings().difficulty = Difficulty.Easy;
            }
            SwitchDifficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void UpdateMusicVolume(float value)
        {
            MusicVolumeSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"Music: {value}%";
            settingsManager.GetSettings().musicVolume = (int)value;
        }
        
        void UpdateSoundVolume(float value)
        {
            SoundVolumeSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"Sound: {value}%";
            settingsManager.GetSettings().sfxVolume = (int)value;
        }
        
        void UpdateSensitivityValue(float value)
        {
            SensitivityValueSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"Sensitivity: {value}%";
            settingsManager.GetSettings().mouseSensitivity = value;
        }
        
        void UpdateFovValue(float value)
        {
            FovValueSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"FOV: {value}";
            settingsManager.GetSettings().fov = (int)value;
        }
        //////////////////////////////////////////////
        ////////////////////Action///////////////////
        UnityAction<SettingsEvent> _action;
        
        public void AddListener(UnityAction<SettingsEvent> action)
        {
            _action = action;
        }
    }
}