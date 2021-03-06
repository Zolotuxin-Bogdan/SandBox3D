﻿using System.Collections;
using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.UI
{
    public class MenuController : MonoBehaviour, ILocalization
    {
        public TextMeshProUGUI randomText;
        //public TextMeshProUGUI single;
        public Image logo;
        public Button singleplayer;
        public Button multiplayer;
        public Button settings;
        public Button quit;

        string[] phrases = new string[] {"Hotter then the sun!", "Minecraft in 3D?", "You reading this text!", "To be ill is not cool", "I will definitely survive!"};

        public static MenuController Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            singleplayer.onClick.AddListener(SingleplayerCallback);
            multiplayer.onClick.AddListener(MultiplayerCallback);
            settings.onClick.AddListener(SettingsCallback);
            quit.onClick.AddListener(CloseGame);
        }

        private void OnEnable() {
            randomText.text = GetRandomText(phrases);
            StartCoroutine(Animate());
        }

        private void OnDisable() {
            StopCoroutine(Animate());
        }

        private string GetRandomText(string[] phrases)
        {
            return phrases[Random.Range(0, phrases.Length)];
        }

        protected int counter = 1;
        private IEnumerator Animate()
        {
            while (true)
            {
                if (randomText.fontSize <= 16)
                {
                    counter = 1;
                }
                if (randomText.fontSize >= 32)
                {
                    counter -= 1;
                }
                randomText.fontSize += counter;
                yield return new WaitForSecondsRealtime(.1f);
            }
        }

        private void CloseGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private void SettingsCallback()
        {
            action.Invoke(MenuEvents.OnSettingsClicked);
        }

        private void MultiplayerCallback()
        {
            action.Invoke(MenuEvents.OnMultiplayerClicked);
        }

        private void SingleplayerCallback()
        {
            action.Invoke(MenuEvents.OnSinglePlayerClicked);
        }

        protected UnityAction<MenuEvents> action;
        public void AddListener(UnityAction<MenuEvents> action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            singleplayer.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.single_player.ToString());
            multiplayer.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.multi_player.ToString());
            settings.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.options.ToString());
            quit.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.quit_game.ToString());
        }
    }
}
