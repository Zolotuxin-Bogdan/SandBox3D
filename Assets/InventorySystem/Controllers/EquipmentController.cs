using System.Collections.Generic;
using InventorySystem.Items;
using Assets.Scripts.Enums;
using UnityEngine;

namespace InventorySystem.Controllers
{
    public class EquipmentController : MonoBehaviour
    {
        [SerializeField] GameObject slot;

        Dictionary<EquipmentType, SlotController> equipmentSlot;
        void Start() {
            equipmentSlot = new Dictionary<EquipmentType, SlotController>();
            BuildContent();
        }
        
        protected void BuildContent() {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(slot, transform).SetActive(true);
            }

            var slots = GetComponentsInChildren<SlotController>();
            equipmentSlot[EquipmentType.Helmet] = slots[0];
            equipmentSlot[EquipmentType.Chest] = slots[1];
            equipmentSlot[EquipmentType.Pants] = slots[2];
            equipmentSlot[EquipmentType.Boots] = slots[3];
        }

        public void AddItem(BaseItem item, UIItem uiItem)
        {
            if (item.type != ItemType.Equipment) return;
            var equipment = (Equipment)item;
            equipmentSlot[equipment.equipmentType].AddItem(uiItem);
        }
    }
}

