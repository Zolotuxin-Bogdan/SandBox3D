using System;
using Assets.InventorySystem.Items;

namespace Assets.InventorySystem
{
    public class Inventory
    {
        protected BaseItem[] items;
        protected readonly int size;
    
        public Inventory(int size) 
        { 
            this.size = size;
            items = new BaseItem[size];
            for (var i = 0; i < items.Length; i++)
            {
                items[i] = null;
            }
        }

        public void AddItem(BaseItem item)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (items[i] == null) {
                    items[i] = item;
                    break;
                }
            }
        }

        public void RemoveItem(int index)
        {
            if (index > size || index < 0) 
                throw new ArgumentOutOfRangeException(nameof(index));
        
            items[index] = null;
        }

        public BaseItem GetItem(int index)
        {
            if (index > size || index < 0) 
                throw new ArgumentOutOfRangeException(nameof(index));
        
            return items[index];
        }

        public void SwitchItems(int index1, int index2)
        {
            if (index1 > size || index1 < 0) 
                throw new ArgumentOutOfRangeException(nameof(index1));
        
            if (index2 > size || index2 < 0) 
                throw new ArgumentOutOfRangeException(nameof(index2));
        
            var item1 = items[index1];
            var item2 = items[index2];
        
            items[index1] =  item2;
            items[index2] = item1;
        }    
    }
}
