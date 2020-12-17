using System;
using System.Collections.Generic;
using Assets.InventorySystem.Items;

public class Inventory
{
    protected List<InventoryItem> items = new List<InventoryItem>();
    protected readonly int size;
    
    public Inventory(int size) 
    { 
        this.size = size;
    }

    public void AddItem(InventoryItem item)
    {
        if (items.Count == size) 
            throw new Exception("Inventory stack overflow!");
        
        items.Add(item);
    }

    public void RemoveItem(int index)
    {
        if (index > size || index < 0) 
            throw new ArgumentOutOfRangeException(nameof(index));
        
        items.RemoveAt(index);
    }

    public InventoryItem GetItem(int index)
    {
        if (index > size || index < 0) 
            throw new ArgumentOutOfRangeException(nameof(index));
        
        return items.ToArray()[index];
    }

    public void SwitchItems(int index1, int index2)
    {
        if (index1 > size || index1 < 0) 
            throw new ArgumentOutOfRangeException(nameof(index1));
        
        if (index2 > size || index2 < 0) 
            throw new ArgumentOutOfRangeException(nameof(index2));
        
        var item1 = items.ToArray()[index1];
        var item2 = items.ToArray()[index2];
        
        items.Insert(index1, item2);
        items.Insert(index2, item1);
    }

    
}
