using System.IO;
using UnityEngine;
using UnityEngine.Events;
using Button = UnityEngine.UI.Button;

namespace Assets.Scripts.UI
{
    public class TexturePackController: MonoBehaviour
    {
        public Button Done;
        public Button OpenFolder;
        private void Start() {
            Done.onClick.AddListener(Submit);
            OpenFolder.onClick.AddListener(ShowFileBrowserDialog);
        }

        private void ShowFileBrowserDialog()
        {
            
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