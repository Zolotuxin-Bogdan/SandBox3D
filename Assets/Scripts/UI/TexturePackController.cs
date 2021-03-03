using System.Collections.Generic;
using System.IO;
using Assets.LocalizationSystem;
using Assets.Scripts.Tools_and_Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Assets.Scripts.UI
{
    public class TexturePackController: MonoBehaviour, ILocalization
    {
        public SettingsManager settings;
        
        public GameObject Item;
        
        public Button Done;
        public Button RefreshList;
        
        public ScrollRect AvailableTexturePacks;
        public ScrollRect SelectedTexturePacks;

        string texturePackPath;
        string[] directories; 
        List<string> loadedDirectories;
        string selectedDirectory = "";
        private void Start() {
            Done.onClick.AddListener(Submit);
            RefreshList.onClick.AddListener(Refresh);
            texturePackPath = Application.dataPath + "\\texturepacks\\";
            loadedDirectories = new List<string>();
        }

        private void Refresh()
        {
           directories = Directory.GetDirectories(texturePackPath);
           ShowDirectories();
        }

        private void ShowDirectories()
        {
            for (int i = 0; i < directories.Length; i++)
            {
                if (directories[i] == selectedDirectory)
                    continue;
                if (loadedDirectories.Contains(directories[i].Remove(0, texturePackPath.Length)))
                    continue;
                CreateTextObject(i, directories[i].Remove(0, texturePackPath.Length), AvailableTexturePacks.content.transform);                
            }
        }

        void CreateTextObject(int id, string text, Transform parent)
        {
            loadedDirectories.Add(text);
            var newItem = Instantiate(Item);
            var labels = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            labels[0].text = text;
            labels[1].text = "SandBox3D texture pack";
            newItem.transform.SetParent(parent);
            newItem.SetActive(true);
            newItem.AddComponent<Button>().onClick.AddListener(
                () => {
                    if (newItem.transform.parent.Equals(SelectedTexturePacks.content.transform))
                    {
                        settings.GetSettings().pathToTexturePack = selectedDirectory = "";
                        newItem.transform.SetParent(parent);    
                    }else if (SelectedTexturePacks.content.childCount < 2) 
                    {
                        settings.GetSettings().pathToTexturePack = selectedDirectory = directories[id];
                        newItem.transform.SetParent(SelectedTexturePacks.content.transform);
                    }
                }
            );
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

        public void SetLocalization()
        {
            throw new System.NotImplementedException();
        }
    }
}