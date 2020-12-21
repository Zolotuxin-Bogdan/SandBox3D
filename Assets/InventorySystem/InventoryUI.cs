using System;
using System.Collections;
using Assets.InventorySystem.Items;
using UnityEngine;
using UnityEngine.UI;
using block = Assets.InventorySystem.Items.Block;
public class InventoryUI : MonoBehaviour
{
    public PlayerController controller;
    public GameObject equipment;
    public GameObject slotsContainer;
    public GameObject hotBar;

    Button[] slots;

    Inventory inventory;
    MeshProvider meshProvider;
    InputSystem input;
    int selectedSlot;
    bool waitingKey;
    private void Start()
    {
        LoadSlots();
        inventory = new Inventory(slots.Length);
        meshProvider = new MeshProvider();
        input = new InputSystem();
        controller.OnDropItemTouched(PickUpCallback);
        waitingKey = false;
        ConfigureSlots();
    }

    private void LoadSlots()
    {
        slots = slotsContainer.GetComponentsInChildren<Button>();
    }

    private void ConfigureSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            AddSlotAction(slots[i], i);
        }
    }

    private void AddSlotAction(Button slot, int index)
    {
        slot.onClick.AddListener(
            () => {
                selectedSlot = index;
                waitingKey = true;
                StartCoroutine("WaitKey");
                Debug.Log("Wait key");
            }
        );
    }

    private IEnumerator WaitKey() {
        while (!input.IsDropKeyPressed())
            yield return null;
        Debug.Log("Drop key pressed");
        DropItem();
        waitingKey = false;
    }

    private void PickUpCallback(string slug)
    {
        var item = CreateItem(slug);
        foreach (var slot in slots)
        {
            if (slot.GetComponentInChildren<Image>().sprite == null)
            {
                slot.GetComponentInChildren<Image>().sprite = item.icon;
                break;
            }
        }
        inventory.AddItem(item);
    }

    private InventoryItem CreateItem(string slug)
    {
        if (slug.Contains("block"))
            return new block();
        if (slug.Contains("armor"))
            return new Armor();
        if (slug.Contains("food"))
            return new Food();
        if (slug.Contains("tool"))
            return new Instrument();
        if (slug.Contains("weapon"))
            return new Weapon();
        throw new ArgumentOutOfRangeException(nameof(slug));
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
        newItem.AddComponent<Item>().item = item;
        newItem.AddComponent<MeshFilter>().mesh = meshProvider.ImportMeshBySlug(item.slug);
    }
}
