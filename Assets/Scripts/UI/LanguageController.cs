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
    public class LanguageController: MonoBehaviour, ILocalization
    {
        public SettingsManager settings;
        public GameObject Item;
        public ScrollRect LanguageList;
        public Button Done;
        public Button ForceUnicodeFont;
        public TextMeshProUGUI LanguageLabel;


        public static LanguageController Instance;

        private void Awake()
        {
            Instance = this;
        }


        private void Start() {
            Done.onClick.AddListener(Submit);
            InitLanguageList();
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

        private void InitLanguageList()
        {
            foreach (Languages language in Enum.GetValues(typeof(Languages)))
            {
                var currentLanguageListItem = Instantiate(Item);
                currentLanguageListItem.GetComponentInChildren<TextMeshProUGUI>().text = language.ToString();
                currentLanguageListItem.GetComponent<Button>().onClick.AddListener(
                    () =>
                    {
                        SettingsManager.Instance.GetSettings().language = language;
                        SettingsManager.Instance.SaveSettings();
                        LocalizationManager.UpdateLocalization();
                        LocalizationSystem.LocalizationSystem.ChangeCurrentLanguage(language);
                    }
                );
                currentLanguageListItem.SetActive(true);
                currentLanguageListItem.transform.parent = LanguageList.content.transform;
            }
        }

        public void SetLocalization()
        {
            Done.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.done.ToString());
            ForceUnicodeFont.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.force_unicode_font.ToString());
            LanguageLabel.text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.language.ToString());
        }
    }
}