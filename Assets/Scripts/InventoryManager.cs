using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryManager
    {
        private List<Item> _items;

        public void Start()
        {
            _items = new List<Item>();
        }

        public void AddItemByName(string itemName)
        {
            _items.Add(new Item{count = 1, name = itemName, maxCount = 64});
        }

        public void RemoveItemByName(string itemName)
        {
            var item = _items.Find(p => p.name == itemName);
            if (item != null)
            {
                item.count -= 1;
                if (item.count < 0)
                    _items.Remove(item);
            }
            else
            {
                Debug.LogError("Item not found");
                return;
            }
        }
    }
}
