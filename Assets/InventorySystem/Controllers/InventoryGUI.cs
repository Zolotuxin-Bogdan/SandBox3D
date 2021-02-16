using UnityEngine;
using System.Linq;
using Assets.InputSystem;

namespace InventorySystem.Controllers
{
    public class InventoryGUI : MonoBehaviour
    {
        public GameObject equipment;
        public GameObject hotBar;
        public GameObject inventory;
        public GameObject parent;
        public GameObject MenuCanvas;
        public GameObject SettingsCanvas;
        public GameObject ConsoleCanvas;
        
        InputSystem inputSystem;
        void Start() {
            inputSystem = InputSystem.instance;
            inputSystem.OnKeyPressed += InputSystem_OnKeyPressed;
            parent.SetActive(false);
        }

        private void InputSystem_OnKeyPressed()
        {
            if (inputSystem.IsInventoryKeyPressed())
            {
                parent.SetActive(!parent.activeSelf);
                equipment.SetActive(!equipment.activeSelf);
                hotBar.SetActive(!hotBar.activeSelf);
                inventory.SetActive(!inventory.activeSelf);
                Cursor.visible = !Cursor.visible;
            }
        }


    }
}