using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class InventoryController: MonoBehaviour
    {
        public PlayerController Controller;

        private InventoryManager _inventoryManager;

        void Start()
        {
            _inventoryManager = new InventoryManager();
            Controller.OnDropItemTouched(PickupItem);
        }

        void PickupItem(string itemName)
        {
            _inventoryManager.AddItemByName(itemName);
        }
    }
}