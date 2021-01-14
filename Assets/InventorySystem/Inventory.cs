using System.Collections.Generic;
using Assets.InventorySystem.Events;
using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.InventorySystem
{  
    public class Inventory : MonoBehaviour 
    {
        public event InventoryAction onItemChangedCallback;
        public List<UIItem> uiItems = new List<UIItem>();
        public List<BaseItem> baseItems = new List<BaseItem>();
        public static Inventory instance {get; set;}
        
        public readonly int INVENTORY_SIZE = 27;

        void Awake() {
            instance = this;
        }        
        public bool Add(BaseItem item0, UIItem item1) {
            if (baseItems.Count >= INVENTORY_SIZE) {
                Debug.Log("Inventory is already full");
                return false;
            }
            var item = baseItems.Find(i => i.name == item0.name);
            if (item != null) {
                item.amount += item1.amount;
                uiItems[baseItems.IndexOf(item)].amount += item1.amount;
            } else {
                baseItems.Add(item0);
                uiItems.Add(item1);
            }
            onItemChangedCallback?.Invoke();
            return true;
        }

        public void Remove(UIItem item) {
            baseItems.RemoveAt(uiItems.IndexOf(item));
            uiItems.Remove(item);
            onItemChangedCallback?.Invoke();
        }
    }
}