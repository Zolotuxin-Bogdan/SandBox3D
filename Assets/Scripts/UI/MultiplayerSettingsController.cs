using System;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MultiplayerSettingsController: MonoBehaviour
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
                settings.GetSettings().chat_displayState = ChatDisplayStates.CommandsOnly;
            }
            else if (text.Contains("Commands Only"))
            {
                text = "Chat: Hidden";
                settings.GetSettings().chat_displayState = ChatDisplayStates.Hidden;
            }
            else if (text.Contains("Hidden"))
            {
                text = "Chat: Shown";
                settings.GetSettings().chat_displayState = ChatDisplayStates.Shown;
            }
            ChatState.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateWebLinks()
        {
            var text = WebLinks.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Web Links: OFF";
                settings.GetSettings().chat_allowWebLinks = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Web Links: ON";
                settings.GetSettings().chat_allowWebLinks = true;
            }
            WebLinks.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdatePromptOnLinks()
        {
            var text = PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Prompt on Links: OFF";
                settings.GetSettings().chat_allowPromptOnLinks = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Prompt on Links: ON";
                settings.GetSettings().chat_allowPromptOnLinks = true;
            }
            PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateColors()
        {
            var text = Colors.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Colors: OFF";
                settings.GetSettings().chat_allowColorsInChat = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Colors: ON";
                settings.GetSettings().chat_allowColorsInChat = true;
            }
            Colors.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateShowCape()
        {
            var text = ShowCape.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("ON"))
            {
                text = "Show Cape: OFF";
                settings.GetSettings().multiplayer_allowCape = false;
            }
            else if (text.Contains("OFF"))
            {
                text = "Show Cape: ON";
                settings.GetSettings().multiplayer_allowCape = true;
            }
            Colors.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateOpacity(float arg0)
        {
            Opacity.GetComponentInChildren<TextMeshProUGUI>().text = $"Opacity: {arg0}%";
            settings.GetSettings().chat_opacity = arg0;
        }

        private void UpdateScale(float arg0)
        {
            if (arg0 < 1)
                Scale.GetComponentInChildren<TextMeshProUGUI>().text = "Scale: OFF";
            else 
                Scale.GetComponentInChildren<TextMeshProUGUI>().text = $"Scale: {arg0}%";
            settings.GetSettings().chat_scale = arg0;
        }

        private void UpdateUnfocusedHeight(float arg0)
        {
            UnfocusedHeight.GetComponentInChildren<TextMeshProUGUI>().text = $"Unfocused Height: {arg0}px";
            settings.GetSettings().chat_unfocusedHeight = arg0;
        }

        private void UpdateFocusedHeight(float arg0)
        {
            FocusedHeight.GetComponentInChildren<TextMeshProUGUI>().text = $"Focused Height: {arg0}%";
            settings.GetSettings().chat_focusedHeight = arg0;
        }

        private void UpdateWidth(float arg0)
        {
            Width.GetComponentInChildren<TextMeshProUGUI>().text = $"Width: {arg0}%";
            settings.GetSettings().chat_width = arg0;
        }

        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}