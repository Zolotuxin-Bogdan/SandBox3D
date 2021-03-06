﻿using System;
using System.IO;
using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SingleplayerMenuController : MonoBehaviour, ILocalization
    {
        public Button createNewWorld;
        public Button playSelectedWorld;
        public Button cancel;
        public Button reCreate;
        public Button rename;
        public Button delete;
        public TextMeshProUGUI SingleplayerLabel;
        public ScrollRect worlds;
        public GameObject item;

        int selectedWorld = -1;

        public static SingleplayerMenuController Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            createNewWorld.onClick.AddListener(CreateWorldCallback);
            playSelectedWorld.onClick.AddListener(RunWorldCallback);
            cancel.onClick.AddListener(CancelCallback);
            reCreate.onClick.AddListener(ReCreateCallback);
            rename.onClick.AddListener(RenameCallback);
            delete.onClick.AddListener(DeleteCallback);
            RefreshWorldsList();
        }

        private void RefreshWorldsList()
        {
            if (!Directory.Exists(Application.dataPath + "\\saves\\"))
                Directory.CreateDirectory(Application.dataPath + "\\saves\\");
            var saves = Directory.GetDirectories(Application.dataPath + "\\saves\\");
            for (int i = 0; i < saves.Length; i++)
            {
                var info = new DirectoryInfo(saves[i]);
                CreateItem(info.Name, info.LastWriteTime, i, worlds.content.transform);
            }
        }

        private void CreateItem(string worldName, DateTime lastWriteTime, int index, Transform parent)
        {
            var newItem = Instantiate(item, parent);
            var labels = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            labels[0].text = worldName;
            labels[1].text = $"{worldName} {lastWriteTime}";
            labels[2].text = "Version: ";
            newItem.GetComponent<Button>().onClick.AddListener(
                () => {
                    selectedWorld = index;
                }
            );
        }

        #region CALLBACKS
        private void DeleteCallback()
        {
            if (selectedWorld > -1)
                Destroy(worlds.content.GetChild(selectedWorld));
        }

        private void RenameCallback()
        {
            action.Invoke(SingleplayerMenuEvents.OnRenameClicked);
        }

        private void ReCreateCallback()
        {
            action.Invoke(SingleplayerMenuEvents.OnRecreateClicked);
        }

        private void CancelCallback()
        {
            action.Invoke(SingleplayerMenuEvents.OnCancelClicked);
        }

        private void RunWorldCallback()
        {
            action.Invoke(SingleplayerMenuEvents.OnRunWorldClicked);
        }

        private void CreateWorldCallback()
        {
            action.Invoke(SingleplayerMenuEvents.OnCreateWorldClicked);
        }
        #endregion
        public string GetSelectedWorldName()
        {
            if (selectedWorld > -1)
                return worlds.content.GetChild(selectedWorld).GetComponentsInChildren<TextMeshProUGUI>()[0].text;
            return null;
        }

        protected UnityAction<SingleplayerMenuEvents> action;

        public void AddListener(UnityAction<SingleplayerMenuEvents> action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            createNewWorld.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.create_new_world.ToString());
            playSelectedWorld.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.play_selected_world.ToString());
            cancel.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.cancel.ToString());
            reCreate.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.re_create.ToString());
            rename.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.rename.ToString());
            delete.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.delete.ToString());
            SingleplayerLabel.text = .GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.single_player.ToString());
        }
    }
}
