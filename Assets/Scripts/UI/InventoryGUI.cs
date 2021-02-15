using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InventoryGUI : MonoBehaviour
    {
        [SerializeField] GameObject content;
        protected InputSystem.InputSystem inputSystem = InputSystem.InputSystem.instance;

        void Start()
        {
            inputSystem.OnKeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed()
        {
            if (inputSystem.IsInventoryKeyPressed())
            {
                content.SetActive(true);
                Cursor.visible = true;
                return;
            }

            if (inputSystem.IsOpenSettingsKeyPressed()
                || inputSystem.IsInventoryKeyPressed())
            {
                content.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}