﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.FileDialog
{
    public class DebugController : MonoBehaviour
    {
        FileDialog explorer;
        bool drawExplorer;
        public string path;
        public Texture2D directoryIcon;
    
        // Start is called before the first frame update
        void Start()
        {
            gameObject.GetComponentInChildren<Button>().onClick.AddListener(SomeButtonCallback);
        }
    
        private void SomeButtonCallback()
        {
            drawExplorer = true;
        }
    
        private void OnGUI()
        {
            if (explorer != null)
                explorer.Draw();
            else
                OnGUIMain();
        }
    
        private void OnGUIMain()
        {
            if (drawExplorer)
            {
                explorer = new FileDialog(
                    "Choose folder...",
                    new Rect(300, 100, 800, 600),
                    FileSelectCallback
                );
                explorer.DirectoryIcon = directoryIcon;
            }
        }
    
        private void FileSelectCallback(string path)
        {
            explorer = null;
            this.path = path;
            drawExplorer = false;
        }
    }
}
