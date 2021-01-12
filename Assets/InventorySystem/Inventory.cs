using System.Collections.Generic;
using Assets.InventorySystem.Events;
using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.InventorySystem
{  
    public class Inventory : MonoBehaviour 
    {
        public event InventoryAction onItemChangedCallback;
        public List<UIItem> items = new List<UIItem>();
        public static Inventory instance {get; set;}
        
        public readonly int INVENTORY_SIZE = 27;

        void Awake() {
            instance = this;
        }        
        public bool Add(UIItem item) {
            if (items.Count >= INVENTORY_SIZE) {
                Debug.Log("Inventory is already full");
                return false;
            }
            items.Add(item);
            onItemChangedCallback?.Invoke();
            return true;
        }

        public void Remove(UIItem item) {
            items.Remove(item);
            onItemChangedCallback?.Invoke();
        }
    }
}