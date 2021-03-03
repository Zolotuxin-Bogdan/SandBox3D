using System;
using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using Assets.Scripts.Tools_and_Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MultiplayerSettingsController: MonoBehaviour, ILocalization
    {
        public SettingsManager settings;
        [Header("Buttons")]
        public Button ChatState;
        public Button WebLinks;
        public Button PromptOnLinks;
        public Button Colors;
        public Button ShowCape;
        public Button Done;
        [Header("Sliders")]
        public Slider Opacity;
        public Slider Scale;
        public Slider UnfocusedHeight;
        public Slider FocusedHeight;
        public Slider Width;

        private void Start() 
        {
            ChatState.onClick.AddListener(UpdateChatState);
            WebLinks.onClick.AddListener(UpdateWebLinks);
            PromptOnLinks.onClick.AddListener(UpdatePromptOnLinks);
            Colors.onClick.AddListener(UpdateColors);
            ShowCape.onClick.AddListener(UpdateShowCape);
            Done.onClick.AddListener(Submit);

            Opacity.onValueChanged.AddListener(UpdateOpacity);
            Scale.onValueChanged.AddListener(UpdateScale);
            UnfocusedHeight.onValueChanged.AddListener(UpdateUnfocusedHeight);
            FocusedHeight.onValueChanged.AddListener(UpdateFocusedHeight);
            Width.onValueChanged.AddListener(UpdateWidth);
        }

        private void Submit()
        {
            action.Invoke();
        }

        private void UpdateChatState()
        {
            var text = ChatState.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("Shown"))
            {
                text = "Chat: Commands Only";
                settings.GetSettings().multiplayer.displayState = ChatDisplayStates.CommandsOnly;
            }
            else if (text.Contains("Commands Only"))
            {
                text = "Chat: Hidden";
                settings.GetSettings().multiplayer.displayState = ChatDisplayStates.Hidden;
            }
            else if (text.Contains("Hidden"))
            {
                text = "Chat: Shown";
                settings.GetSettings().multiplayer.displayState = ChatDisplayStates.Shown;
            }
            ChatState.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateWebLinks()
        {
            var text = WebLinks.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Web Links: OFF";
                settings.GetSettings().multiplayer.allowWebLinks = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Web Links: ON";
                settings.GetSettings().multiplayer.allowWebLinks = true;
            }
            WebLinks.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdatePromptOnLinks()
        {
            var text = PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Prompt on Links: OFF";
                settings.GetSettings().multiplayer.allowPromptOnLinks = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Prompt on Links: ON";
                settings.GetSettings().multiplayer.allowPromptOnLinks = true;
            }
            PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateColors()
        {
            var text = Colors.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Colors: OFF";
                settings.GetSettings().multiplayer.allowColorsInChat = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Colors: ON";
                settings.GetSettings().multiplayer.allowColorsInChat = true;
            }
            Colors.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateShowCape()
        {
            var text = ShowCape.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Show Cape: OFF";
                settings.GetSettings().multiplayer.allowCape = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Show Cape: ON";
                settings.GetSettings().multiplayer.allowCape = true;
            }
            Colors.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateOpacity(float arg0)
        {
            Opacity.GetComponentInChildren<TextMeshProUGUI>().text = $"Opacity: {arg0}%";
            settings.GetSettings().multiplayer.opacity = (int)arg0;
        }

        private void UpdateScale(float arg0)
        {
            if (arg0 < 1)
                Scale.GetComponentInChildren<TextMeshProUGUI>().text = "Scale: OFF";
            else 
                Scale.GetComponentInChildren<TextMeshProUGUI>().text = $"Scale: {arg0}%";
            settings.GetSettings().multiplayer.scale = (int)arg0;
        }

        private void UpdateUnfocusedHeight(float arg0)
        {
            UnfocusedHeight.GetComponentInChildren<TextMeshProUGUI>().text = $"Unfocused Height: {arg0}px";
            settings.GetSettings().multiplayer.unfocusedHeight = (int)arg0;
        }

        private void UpdateFocusedHeight(float arg0)
        {
            FocusedHeight.GetComponentInChildren<TextMeshProUGUI>().text = $"Focused Height: {arg0}%";
            settings.GetSettings().multiplayer.focusedHeight = (int)arg0;
        }

        private void UpdateWidth(float arg0)
        {
            Width.GetComponentInChildren<TextMeshProUGUI>().text = $"Width: {arg0}%";
            settings.GetSettings().multiplayer.width = (int)arg0;
        }

        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            throw new NotImplementedException();
        }
    }
}