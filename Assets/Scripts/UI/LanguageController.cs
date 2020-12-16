using System;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LanguageController: MonoBehaviour
    {
        public SettingsManager settings;
        public GameObject Item;
        public ScrollRect LanguageList;
        public Button Done;
        
        string[] languages;
        int selectedLanguage = -1;
        private void Start() {
            Done.onClick.AddListener(Submit);
            GenerateLanguageList();
        }

        private void GenerateLanguageList()
        {
            languages = System.Enum.GetNames(typeof(Languages));
            ShowLanguages();
        }

        private void ShowLanguages()
        {
            for (int i = 0; i < languages.Length; i++)
            {
                if (i == selectedLanguage)
                    continue;
                CreateLanguageItem(i, languages[i], LanguageList.content.transform);
            }
        }

        private void CreateLanguageItem(int index, string text, Transform parent)
        {
            var newitem = Instantiate(Item);
            newitem.GetComponentInChildren<TextMeshProUGUI>().text = text;
            newitem.GetComponent<Button>().onClick.AddListener(
                () => {
                    selectedLanguage = index;
                    settings.GetSettings().language = (Languages)System.Enum.GetValues(typeof(Languages)).GetValue(index);
                }
            );
            newitem.SetActive(true);
            newitem.transform.SetParent(parent);
        }

        private void Submit()
        {
            action.Invoke();
        }
        
        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}