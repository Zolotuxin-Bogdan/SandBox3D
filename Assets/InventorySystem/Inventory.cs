using System.Collections.Generic;
using InventorySystem.Events;
using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem
{  
    public class Inventory : MonoBehaviour 
    {
        public event InventoryAction OnItemChangedCallback;
        public List<UIItem> uiItems = new List<UIItem>();
        public List<BaseItem> baseItems = new List<BaseItem>();
        public static Inventory instance {get; set;}
        
        public readonly int INVENTORY_SIZE = 27;
        void Awake() {
            instance = this;
        }        
        public bool Add(BaseItem itemInfo, UIItem uiItemInfo) {
            if (baseItems.Count >= INVENTORY_SIZE) {
                Debug.Log("inventory overflow");
                return false;
            }

            if (itemInfo == null)
            {
                Debug.Log("base item isn't set");
                return false;
            }
            else
            {
                if (itemInfo.name == null)
                {
                    Debug.Log("item name isn't set");
                    return false;
                }
            }

            if (uiItemInfo == null)
            {
                Debug.Log("ui item isn't set");
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
            
            OnItemChangedCallback?.Invoke();
            return true;
        }

        public void Remove(UIItem item) {
            baseItems.RemoveAt(uiItems.IndexOf(item));
            uiItems.Remove(item);
            OnItemChangedCallback?.Invoke();
        }
    }
}