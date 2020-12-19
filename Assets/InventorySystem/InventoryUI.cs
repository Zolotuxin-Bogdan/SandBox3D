using System;
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

    GameObject[] slots;

    Inventory inventory;
    MeshProvider meshProvider;
    int selectedSlot;
    bool waitingKey;
    private void Start()
    {
        inventory = new Inventory(slots.Length);
        meshProvider = new MeshProvider();
        controller.OnDropItemTouched(PickUpCallback);
        waitingKey = false;
        LoadSlots();
        ConfigureSlots();
    }

    private void LoadSlots()
    {
        slots = slotsContainer.GetComponentsInChildren<GameObject>();
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
