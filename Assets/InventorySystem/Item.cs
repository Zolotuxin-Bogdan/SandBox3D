using Assets.InventorySystem.Items;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected InventoryItem _item;
    public InventoryItem item 
    { 
        get => _item;
        set => _item = value; 
    }
}
