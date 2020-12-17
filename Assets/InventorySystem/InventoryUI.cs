﻿using System;
using Assets.InventorySystem.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public PlayerController controller;
    public GameObject[] slots;

    Inventory inventory;
    int selectedSlot;
    bool waitingKey;
    private void Start()
    {
        inventory = new Inventory(slots.Length);
        controller.OnDropItemTouched(PickUpCallback);
        waitingKey = false;
        ConfigureSlots();
    }

    private void ConfigureSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            AddSlotAction(slots[i], i);
        }
    }

    private void AddSlotAction(GameObject slot, int index)
    {
        slot.GetComponent<Button>().onClick.AddListener(
            () => {
                selectedSlot = index;
                waitingKey = true;
            }
        );
    }

    private void OnGUI() {
        if (waitingKey)
        {
            if (Event.current.isKey && (Event.current.keyCode == KeyCode.Q))
            {
                DropItem();
                waitingKey = false;
            }
        }
    }

    private void PickUpCallback(string slug)
    {
        //ItemConstruct.ConstructItem(slug);
        //inventory.AddItem(item);
    }

    private void DropItem()
    {
        var item = inventory.GetItem(selectedSlot);
        inventory.RemoveItem(selectedSlot);
        AddItemToScene(item);
    }

    private void AddItemToScene(InventoryItem item)
    {
        var newItem = new GameObject(item.name);
        newItem.AddComponent<Rigidbody>();
        newItem.AddComponent<MeshRenderer>();
        //newItem.AddComponent<Item>().item = item;
        //newItem.AddComponent<MeshFilter>().mesh = MeshProvider.GetMesh(item.slug);
    }
}
