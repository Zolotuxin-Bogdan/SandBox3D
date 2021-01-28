using System.Collections.Generic;
using Assets.InventorySystem.Items;
using UnityEngine;

namespace Assets.InventorySystem.Controllers
{
    public class HotBarController : MonoBehaviour
    {
        [SerializeField] GameObject slot;
        SlotController[] slots;
        List<BaseItem> items;

        private void Start()
        {
            items = new List<BaseItem>();
            BuildContent();
        }

        private void BuildContent()
        {
            for (var i = 0; i < 9; i++)
            {
                Instantiate(slot, transform).SetActive(true);
            }

            slots = GetComponentsInChildren<SlotController>();
        }


        public void AddItem(BaseItem item, UIItem uiItem)
        {
            if (item == null) return;
            if (uiItem == null) return;
            if (!items.Exists(i => i.name == item.name))
            {
                items.Add(item);
                slots[items.IndexOf(item)].AddItem(uiItem);
            } else
            {
                items.Find(i => i.name == item.name).amount += item.amount;
                uiItem.amount += slots[items.IndexOf(item)].item.amount;
                slots[items.IndexOf(item)].AddItem(uiItem);

            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (items[i] == null)
                {
                    slots[i].ClearSlot();
                }
            }
        }
    }
}

