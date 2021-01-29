using UnityEngine;
using System.Collections;
using Assets.InputSystem;

namespace InventorySystem.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] EquipmentController equipment;
        [SerializeField] HotBarController hotBar;
        [SerializeField] InventoryController inventory;
        [SerializeField] SlotController slot;
        [SerializeField] GameObject parent;
        InputSystem inputSystem;
        void Start() {
            inputSystem = InputSystem.instance;
            inputSystem.OnKeyPressed += InputSystem_OnKeyPressed;
            parent.SetActive(false);
        }

        private void InputSystem_OnKeyPressed()
        {
            if (inputSystem.IsInventoryKeyPressed())
                parent.SetActive(!parent.activeSelf);
        }


    }
}