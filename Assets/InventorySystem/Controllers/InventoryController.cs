using System.Collections;
using Assets.InputSystem;
using UnityEngine;

namespace InventorySystem.Controllers
{
    public class InventoryController : MonoBehaviour {
        
        public Transform parent;
        
        public Transform player;
        Inventory inventory;
        [SerializeField]SlotController[] slots;

        [SerializeField]GameObject slot;
        
        InputSystem input;
        void Start() {
            inventory = Inventory.instance;
            inventory.OnItemChangedCallback += UpdateUI;
            input = InputSystem.instance;
            for (int i = 0; i < inventory.INVENTORY_SIZE; i++)
            {
                var newSlot = Instantiate(slot, parent);
                newSlot.SetActive(true);
            }
            slots = parent.GetComponentsInChildren<SlotController>();
        }
        protected void UpdateUI() {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.uiItems.Count) {
                    slots[i].AddItem(inventory.uiItems[i]);
                } else {
                    slots[i].ClearSlot();
                }
            }
        }

        private void Update() {
            StartCoroutine(WaitDropKey());
        }

        bool dropping = false;
        IEnumerator WaitDropKey() {
            while (!input.IsDropKeyPressed())
            {
                dropping = false;
                yield return null;
            }
            if (dropping)
                yield return null;
            else {
                // 
                //SceneEditor.instance.AddItem(new Scripts.DTO.BlockDto {BlockId = 1, Position = player.position});
                // new SceneEditor().AddItem(
                //     new Items.BaseItem{type = Scripts.Enums.ItemType.Block, slug = "item.block.cobblestone_FullSizeBlock:0"},
                //     player);
                dropping = true;
            }
            // inventory.Remove(slots[0].item);
        }
    }
}