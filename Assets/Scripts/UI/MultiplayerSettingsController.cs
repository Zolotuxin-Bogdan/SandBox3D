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


        private string _chatState;
        private string _webLinks;
        private string _promptOnLinks;
        private string _colors;
        private string _showCape;
        private string _on;
        private string _off;
        public static MultiplayerSettingsController Instance;

        private void Awake()
        {
            Instance = this;
        }

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
        #region CALLBACKS
        private void Submit()
        {
            action.Invoke();
        }

        private void UpdateChatState()
        {
            var text = ChatState.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("Shown"))
            {
                text = $"{_chatState}: Commands Only";
                settings.GetSettings().multiplayer.displayState = ChatDisplayStates.CommandsOnly;
            }
            else if (text.Contains("Commands Only"))
            {
                text = $"{_chatState}: Hidden";
                settings.GetSettings().multiplayer.displayState = ChatDisplayStates.Hidden;
            }
            else if (text.Contains("Hidden"))
            {
                text = $"{_chatState}: Shown";
                settings.GetSettings().multiplayer.displayState = ChatDisplayStates.Shown;
            }
            ChatState.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateWebLinks()
        {
            var text = WebLinks.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains(_on.ToUpper()))
            {
                text = $"{_webLinks}: {_off.ToUpper()}";
                settings.GetSettings().multiplayer.allowWebLinks = false;
            }
            else if (text.Contains(_off.ToUpper()))
            {
                text = $"{_webLinks}: {_on.ToUpper()}";
                settings.GetSettings().multiplayer.allowWebLinks = true;
            }
            WebLinks.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdatePromptOnLinks()
        {
            var text = PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains(_on.ToUpper()))
            {
                text = $"{_promptOnLinks}: {_off.ToUpper()}";
                settings.GetSettings().multiplayer.allowPromptOnLinks = false;
            }
            else if (text.Contains(_off.ToUpper()))
            {
                text = $"{_promptOnLinks}: {_on.ToUpper()}";
                settings.GetSettings().multiplayer.allowPromptOnLinks = true;
            }
            PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateColors()
        {
            var text = Colors.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains(_on.ToUpper()))
            {
                text = $"{_colors}: {_off.ToUpper()}";
                settings.GetSettings().multiplayer.allowColorsInChat = false;
            }
            else if (text.Contains(_off.ToUpper()))
            {
                text = $"{_colors}: {_on.ToUpper()}";
                settings.GetSettings().multiplayer.allowColorsInChat = true;
            }
            Colors.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateShowCape()
        {
            var text = ShowCape.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains(_on.ToUpper()))
            {
                text = $"{_showCape}: {_off.ToUpper()}";
                settings.GetSettings().multiplayer.allowCape = false;
            }
            else if (text.Contains(_off.ToUpper()))
            {
                text = $"{_showCape}: {_on.ToUpper()}";
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
        #endregion
        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            _off = LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.off.ToString());
            _on = LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.on.ToString());

            _chatState =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.chat_state.ToString());
            ChatState.GetComponentInChildren<TextMeshProUGUI>().text = _chatState + ": Shown";
            
            _webLinks = 
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.web_links.ToString());
            WebLinks.GetComponentInChildren<TextMeshProUGUI>().text = $"{_webLinks}: {_on.ToUpper()}";
            
            _promptOnLinks =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.prompt_on_links.ToString());
            PromptOnLinks.GetComponentInChildren<TextMeshProUGUI>().text = $"{_promptOnLinks}: {_on.ToUpper()}";

            _colors =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.colors.ToString());
            Colors.GetComponentInChildren<TextMeshProUGUI>().text = $"{_colors}: {_on.ToUpper()}";

            _showCape =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.show_cape.ToString());
            ShowCape.GetComponentInChildren<TextMeshProUGUI>().text = $"{_showCape}: {_on.ToUpper()}";

            Done.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.done.ToString());
        }
    }
}