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
        public bool Add(BaseItem itemInfo, UIItem uiItemInfo) {
            if (baseItems.Count >= INVENTORY_SIZE) {
                Debug.Log("Inventory is already full");
                return false;
            }

            var item = baseItems.Find(i => i.name == itemInfo.name);
            
            if (item != null) {
                item.amount += itemInfo.amount;
                uiItems[baseItems.IndexOf(item)].amount += uiItemInfo.amount;
            } else {
                baseItems.Add(itemInfo);
                uiItems.Add(uiItemInfo);
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