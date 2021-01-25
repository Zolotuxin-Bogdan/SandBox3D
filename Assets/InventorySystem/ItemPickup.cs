using System.Collections;
using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.InventorySystem
{
    public class ItemPickup : Interactable {
        public UIItem item1;
        public BaseItem item;
        
        public int pickupDelay { get; set; } = 0;

        bool delayEnd = false;
        public override void Interact() {
            if (delayEnd)
                PickUp();
        }

        public override void OnCreate() {
            if (pickupDelay <= 0)
                delayEnd = true;
            else
                StartCoroutine(Timer());
        }

        protected void PickUp() {
            Inventory.instance.Add(item, item1);
            print($"Item {item.name} added to inventory");
            if (gameObject.transform.parent != null)
                Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }

        IEnumerator Timer() {
            yield return new WaitForSeconds(pickupDelay);
            delayEnd = true;
        }
    }
}