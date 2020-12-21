﻿using System.Collections;
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

    public bool isLifted;

    private void Awake() {
        isLifted = false;
        StartCoroutine(AllowLifted());
    }

    private IEnumerator AllowLifted()
    {
        yield return new WaitForSecondsRealtime(2);
        isLifted = true;
    }
}