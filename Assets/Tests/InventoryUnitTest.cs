using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using InventorySystem.Items;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryUnitTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestOverflowInventoryValidation()
        {
            try
            {
                GameObject go = new GameObject("TestInventory");
                go.AddComponent<Inventory>();
                Inventory inventory = Inventory.instance;
                for (int i = 0; i < inventory.INVENTORY_SIZE + 1; i++)
                {
                    inventory.Add(new BaseItem { name = $"{i}" }, new UIItem());
                }
                
                Debug.Log("checking items count...");
                Assert.Less(inventory.baseItems.Count, inventory.INVENTORY_SIZE + 1);
                
                Debug.Log("checking correct method closing...");
                Assert.False(inventory.Add(new BaseItem { name = "item" }, new UIItem()));
            }
            catch (Exception e)
            {
                Debug.Log($"test failed, output: {e}");
                throw;
            }
        }

        [Test]
        public void TestParametersNullValidation()
        {
            GameObject go = new GameObject("TestInventory");
            go.AddComponent<Inventory>();
            Inventory inventory = Inventory.instance;
            
            Debug.Log("checking first parameter for null...");
            Assert.False(inventory.Add(null, new UIItem()));

            Debug.Log("checking second parameter for null...");
            Assert.False(inventory.Add(new BaseItem(), null));
        }

        [Test]
        public void TestCallbackInvoking()
        {
            bool invoke = false;

            GameObject go = new GameObject("TestInventory");
            go.AddComponent<Inventory>();
            Inventory inventory = Inventory.instance;

            Debug.Log("set callback handler...");
            inventory.OnItemChangedCallback += () => { invoke = true; };
            
            Debug.Log("try invoking...");
            inventory.Add(new BaseItem(), new UIItem());
            Assert.True(invoke);
        }
    }
}
