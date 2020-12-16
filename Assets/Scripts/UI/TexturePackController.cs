using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Assets.Scripts.UI
{
    public class TexturePackController: MonoBehaviour
    {
        public SettingsManager settings;
        
        public GameObject Item;
        
        public Button Done;
        public Button RefreshList;
        
        public ScrollRect AvailableTexturePacks;
        public ScrollRect SelectedTexturePacks;

        string texturePackPath;
        string[] directories; 
        string selectedDirectory = "";
        private void Start() {
            Done.onClick.AddListener(Submit);
            RefreshList.onClick.AddListener(Refresh);
            texturePackPath = Application.dataPath + "\\texturepacks\\";
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
                CreateTextObject(i, directories[i].Remove(0, texturePackPath.Length), AvailableTexturePacks.content.transform);                
            }
        }

        void CreateTextObject(int id, string text, Transform parent)
        {
            var newItem = Instantiate(Item);
            var labels = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            labels[0].text = text;
            labels[1].text = "SandBox3D texture pack";
            newItem.transform.SetParent(parent);
            newItem.SetActive(true);
            newItem.AddComponent<Button>().onClick.AddListener(
                () => {
                    settings.GetSettings().pathToTexturePack = selectedDirectory = directories[id];
                    newItem.transform.SetParent(SelectedTexturePacks.content.transform);
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
    }
}