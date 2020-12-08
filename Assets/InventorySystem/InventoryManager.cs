using System.Collections.Generic;
using Assets.InventorySystem.Items;

namespace Assets.InventorySystem
{
    public class InventoryManager
    {
        public int inventorySize;
        private List<InventoryItem> _itemList;

        public InventoryManager(List<InventoryItem> itemList)
        {
            _itemList = itemList;
        }

        public void AddItem(InventoryItem item)
        {
            _itemList.Add(item);
        }

        public void AddItemTo(InventoryItem item, int index)
        {
            
        }

        public void DeleteItem(int index)
        {
            _itemList.RemoveAt(index);
        }

        public int FindBySlugItem(string slug)
        {
            return _itemList.FindIndex(p => p.slug == slug);
        }

        public void DropItemList()
        {
            _itemList.Clear();
        }
    }
}