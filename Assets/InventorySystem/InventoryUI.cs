using System.Collections;
using Assets.InventorySystem.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController controller;
    public GameObject equipment;
    public GameObject slotsContainer;
    public GameObject hotBar;
    public GameObject item;

    public int inventorySize = 27;
    public int inventoryColumnSize = 9;


    Inventory inventory;
    MeshProvider meshProvider;
    InputSystem input;
    int selectedSlot;
    bool isCoroutineRunning = false;
    bool isItemDragging = false;

    private void Start()
    {
        InitializationInventory();
        meshProvider = new MeshProvider();
        input = new InputSystem();
        controller.OnDropItemTouched(PickUpCallback);   
    }

    protected void InitializationInventory() {
        inventory = new Inventory(inventorySize);
        
        var inventoryStyle = slotsContainer.GetComponent<GridLayoutGroup>();
        
        inventoryStyle.padding = new RectOffset(10, 10, 10, 10);
        inventoryStyle.cellSize = new Vector2(36, 36);
        inventoryStyle.spacing = new Vector2(4, 4);
        inventoryStyle.childAlignment = TextAnchor.UpperCenter;
        inventoryStyle.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        inventoryStyle.constraintCount = inventoryColumnSize;

        for (var i = 0; i < inventorySize; i++)
        {
            var newItem = Instantiate(item);
            newItem.GetComponent<Button>().onClick.AddListener(
                () => {
                    if (isCoroutineRunning) {
                        StopAllCoroutines();
                        isCoroutineRunning = false;
                    }
                    selectedSlot = i;
                    StartCoroutine(WaitAction());
                }
            );
            newItem.transform.SetParent(slotsContainer.transform);
            newItem.SetActive(true);
        }
    }

    protected IEnumerator WaitAction() {
        isCoroutineRunning = true;
        while (!input.IsDropKeyPressed() && !isItemDragging)
            yield return null;
        if (isItemDragging) { 
            OnItemDragged();
        } else {
            if (input.IsDropKeyPressed()) {
                OnItemDropped();
            }
        }
    }

    protected void PickUpCallback(string path) { 
        // AddItem(item);
        AddItem(new BaseItem());
    }

    protected void OnItemDropped() { 
        var item = inventory.GetItem(selectedSlot);
        inventory.RemoveItem(selectedSlot);
        var uiInventory = slotsContainer.GetComponentsInChildren<Button>();
        //uiInventory[selectedSlot].
    }

    protected void OnItemDragged() { }


    protected void AddItem(BaseItem item) { 
        inventory.AddItem(item);
        var uiItem = new InventoryItem();
        uiItem.count = item.count;
        if (item is Armor) {
            uiItem.properties.Add(ItemTypes.Armor);
            uiItem.properties.Add(ItemTypes.IsCraftable);
            uiItem.stackSize = 1;

        } else if (item is Weapon) {
            uiItem.properties.Add(ItemTypes.Weapon);
            uiItem.properties.Add(ItemTypes.IsCraftable);
            uiItem.stackSize = 1;

        } else if (item is Tool) {
            uiItem.properties.Add(ItemTypes.Tool);
            uiItem.properties.Add(ItemTypes.IsCraftable);
            uiItem.stackSize = 1;

        } else if (item is Food) {
            uiItem.properties.Add(ItemTypes.Food);
            uiItem.properties.Add(ItemTypes.IsStackable);
            uiItem.stackSize = 64;

        } else if (item is Assets.InventorySystem.Items.Block) {
            uiItem.properties.Add(ItemTypes.Block);
            uiItem.properties.Add(ItemTypes.IsStackable);
            uiItem.stackSize = 64;

        }
        SetIcon(uiItem, item.slug); 
    }
    
    protected void SetIcon(InventoryItem item, string pathToSprite) { 
        item.icon = Resources.Load<Sprite>(pathToSprite);
    }

    protected void AddItemToScene(BaseItem item, bool isDropped = false) { 
        // ItemObject.Instance();
        // ItemObject.BeginSpawn();
        //    ItemObject.item = item;
        //    if (isDropped) {
        //        ItemObject.MoveTo(new Vector2(Screen.width/2, Screen.height/2), 1f);
        //    } else {
        //        Character.RightHand.SetItem(ItemObject);
        //        Camera.DrawableRightHand.Draw(ItemObject);
        //    }
        // ItemObject.EndSpawn();
        // 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isItemDragging = eventData.dragging;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isItemDragging = eventData.dragging;
    }
}