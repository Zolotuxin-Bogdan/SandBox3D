﻿using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SettingsController: MonoBehaviour
    {
        private Difficulty gameDifficulty;

        private FlagState touchscreenModeState;

        private FlagState mouseInvertState;
        //////////////////////////////////////////////
        ///////////////Simple buttons////////////////
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
        public Slider MusicVolumeSlider;
        public Slider SoundVolumeSlider;
        public Slider SensitivityValueSlider;
        public Slider FovValueSlider;
        //////////////////////////////////////////////
        ////////////////Unity Messages///////////////
        private void Start() {
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
            
            MusicVolumeSlider.onValueChanged.AddListener(DisplayMusicVolume);
            SoundVolumeSlider.onValueChanged.AddListener(DisplaySoundVolume);
            SensitivityValueSlider.onValueChanged.AddListener(DisplaySensitivityValue);
            FovValueSlider.onValueChanged.AddListener(DisplayFovValue);
        }
        //////////////////////////////////////////////
        ////////////////////Events///////////////////
        void Submit()
        {
            // before invoke -> save all settings
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
            if (text.Contains(FlagState.Off.ToString().ToUpper()))
            {
                text = $"Touchscreen Mode: {FlagState.On.ToString().ToUpper()}";
                touchscreenModeState = FlagState.On;
            }
            else if (text.Contains(FlagState.On.ToString().ToUpper()))
            {
                text = $"Touchscreen Mode: {FlagState.Off.ToString().ToUpper()}";
                touchscreenModeState = FlagState.Off;
            }

            SwitchTouchscreenModeButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void SwitchMouseInvertValue()
        {
            var text = SwitchMouseInvertButton.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains(FlagState.Off.ToString().ToUpper()))
            {
                text = $"Invert Mouse: {FlagState.On.ToString().ToUpper()}";
                mouseInvertState = FlagState.On;
            }
            else if (text.Contains(FlagState.On.ToString().ToUpper()))
            {
                text = $"Invert Mouse: {FlagState.Off.ToString().ToUpper()}";
                mouseInvertState = FlagState.Off;
            }
            SwitchMouseInvertButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void SwitchDifficulty()
        {
            var text = SwitchDifficultyButton.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains(Difficulty.Easy.ToString()))
            {
                text = $"Difficulty: {Difficulty.Normal.ToString()}";
                gameDifficulty = Difficulty.Normal;
            }
            else if (text.Contains(Difficulty.Normal.ToString()))
            {
                text = $"Difficulty: {Difficulty.Hard.ToString()}";
                gameDifficulty = Difficulty.Hard;
            }
            else if (text.Contains(Difficulty.Hard.ToString()))
            {
                text = $"Difficulty: {Difficulty.Peaceful.ToString()}";
                gameDifficulty = Difficulty.Peaceful;
            }
            else if (text.Contains(Difficulty.Peaceful.ToString()))
            {
                text = $"Difficulty: {Difficulty.Easy.ToString()}";
                gameDifficulty = Difficulty.Easy;
            }
            SwitchDifficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void DisplayMusicVolume(float value)
        {
            MusicVolumeSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"Music: {value}%";
        }
        
        void DisplaySoundVolume(float value)
        {
            SoundVolumeSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"Sound: {value}%";
        }
        
        void DisplaySensitivityValue(float value)
        {
            SensitivityValueSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"Sensitivity: {value}%";
        }
        
        void DisplayFovValue(float value)
        {
            FovValueSlider.GetComponentInChildren<TextMeshProUGUI>().text = $"FOV: {value}";
        }
        //////////////////////////////////////////////
        ////////////////////Action///////////////////
        private UnityAction<SettingsEvent> _action;
        
        public void AddListener(UnityAction<SettingsEvent> action)
        {
            _action = action;
        }
    }
}