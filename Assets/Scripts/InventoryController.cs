using System.Collections.Generic;
using Assets.InventorySystem;
using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryController: MonoBehaviour
    {
        public PlayerController Controller;

        private InventoryManager _inventoryManager;

        void Start()
        {
            _inventoryManager = new InventoryManager(new List<InventoryItem>());
            Controller.OnDropItemTouched(PickupItem);
        }

        void PickupItem(string itemName)
        {
            //_inventoryManager.AddItem();
        }

        void DropItem()
        {
            //_inventoryManager.DeleteItem();
        }
    }
}