using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.InventorySystem
{
    public class ItemPickup : Interactable {
        public UIItem item;

        public override void Interact()
        {
            base.Interact();

            PickUp();
        }

        protected void PickUp() {
            Inventory.instance.Add(item);
            Destroy(gameObject);
        }
    }
}