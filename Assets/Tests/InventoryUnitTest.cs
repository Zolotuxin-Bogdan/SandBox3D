using Assets.InventorySystem;
using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.Tests
{
    public class InventoryUnitTest {
        public static void TestReturnFalseWhenInventoryFull() {
            Inventory inventory = new Inventory();
            for (int i = 0; i < inventory.INVENTORY_SIZE; i++)
            {
                inventory.Add(new BaseItem(), new UIItem());
            }
            if (inventory.Add(new BaseItem(), new UIItem()))
                Debug.LogError(
                    @"InventoryUnitTest.TestReturnFalseWhenInventoryFull:
                            an item cannot be added to a filled inventory"
                );
        }
        public static void TestAddingIdenticalItems() {
            Inventory inventory = new Inventory();
            inventory.Add(new BaseItem{name = "item"}, new UIItem());
            inventory.Add(new BaseItem{name = "item"}, new UIItem());
            if (inventory.baseItems.Count != 1)
                Debug.LogError(
                    @"InventoryUnitTest.TestAddingIdenticalItems:
                            identical items must be written into one object"
                );
        }
        public static void TestOnItemChangedCallbackIsInvoking() {
            Inventory inventory = new Inventory();
            bool isCalling = false;
            inventory.onItemChangedCallback += () => { isCalling = true;};
            inventory.Add(new BaseItem(), new UIItem());
            if (!isCalling)
                Debug.LogError(
                    @"InventoryUnitTest.TestOnItemChangedCallbackIsInvoking:
                            after adding the item to the inventory, the event should be called"
                );
        }
        public static void TestNullValidation() {
            Inventory inventory = new Inventory();
            try
            {
                inventory.Add(null, new UIItem());
                Debug.LogError(
                    @"InventoryUnitTest.TestNullValidation:
                            the input value must be checked for null"
                );
            } catch (System.Exception) {throw;}
            
            try
            {
                inventory.Add(new BaseItem(), null);
                Debug.LogError(
                    @"InventoryUnitTest.TestNullValidation:
                            the input value must be checked for null"
                );
                
            } catch (System.Exception) {throw;}
            
            try
            {
                inventory.Add(null, null);
                Debug.LogError(
                    @"InventoryUnitTest.TestNullValidation:
                            the input value must be checked for null"
                );
            } catch (System.Exception) {throw;}

        }
        public static void TestItemRemoving() {
            Inventory inventory = new Inventory();
            UIItem uiItem = new UIItem();
            inventory.Add(new BaseItem(), uiItem);
            inventory.Remove(uiItem);
            if (inventory.baseItems.Count != 0)
                Debug.LogError(
                    @"InventoryUnitTest.TestItemRemoving:
                            item must be removed from inventory"
                );
        }
    }
}