using System.Collections.Generic;
using Assets.InventorySystem.Controllers;
using UnityEngine;
using Assets.Scripts;
using System.Collections;

namespace Assets.InventorySystem
{
    public class InventoryUI : MonoBehaviour {
        public Transform parent;
        
        Inventory inventory;
        [SerializeField]SlotController[] slots;

        [SerializeField]GameObject slot;

        void Start() {
            inventory = Inventory.instance;
            inventory.onItemChangedCallback += UpdateUI;
            
            for (int i = 0; i < inventory.INVENTORY_SIZE; i++)
            {
                var newSlot = Instantiate(slot, parent);
                newSlot.SetActive(true);
            }

            slots = parent.GetComponentsInChildren<SlotController>();

            StartCoroutine(DropItem());
        }
        protected void UpdateUI() {
            print("HERE");
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count) {
                    slots[i].AddItem(inventory.items[i]);
                } else {
                    slots[i].ClearSlot();
                }
            }
        }

        IEnumerator DropItem() {
            while (!new InputSystem().IsDropKeyPressed())
            {
                yield return null;
            }
            
            inventory.Remove(slots[slots.Length].item);
        }
    }
}