using System.Collections;
using Assets.InventorySystem.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public PlayerController controller;
    public GameObject equipment;
    public GameObject slotsContainer;
    public GameObject hotBar;
    public GameObject item;

    public int slotCount = 27;
    public int columnCount = 9;


    Inventory inventory;
    MeshProvider meshProvider;
    InputSystem input;
    int selectedSlot;
    
    private void Start()
    {
        LoadSlots();
        inventory = new Inventory(slotCount);
        meshProvider = new MeshProvider();
        input = new InputSystem();
        controller.OnDropItemTouched(PickUpCallback);
        ConfigureSlots();
    }

    private void LoadSlots()
    {
        var container = slotsContainer.GetComponent<GridLayoutGroup>();
        container.constraintCount = 9;
    }

    private void ConfigureSlots()
    {
        for (int i = 0; i < slotCount; i++)
        {
            AddSlotAction(Instantiate(item).GetComponent<Button>(), i);
        }
    }

    private void AddSlotAction(Button slot, int index)
    {
        slot.onClick.AddListener(
            () => {
                selectedSlot = index;
                StartCoroutine("WaitKey");
                Debug.Log("Wait key");
            }
        );
        slot.gameObject.transform.SetParent(slotsContainer.transform);
        slot.gameObject.SetActive(true);
    }

    private IEnumerator WaitKey() {
        while (!input.IsDropKeyPressed())
            yield return null;
        Debug.Log("Drop key pressed");
        DropItem();
    }

    private void PickUpCallback(string slug)
    {
        var slots = slotsContainer.GetComponentsInChildren<Button>();
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
        //return new InventoryItem{slug = slug};
        return new InventoryItem();
    }

    private void DropItem()
    {
        var item = inventory.GetItem(selectedSlot);
        inventory.RemoveItem(selectedSlot);
        AddItemToScene(item);
    }

    private void AddItemToScene(InventoryItem item)
    {
        //new SceneEditor().AddItem(item);
    }
}