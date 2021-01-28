using System.Collections;
using System.Collections.Generic;
using Assets.InventorySystem.Controllers;
using UnityEngine;

namespace Assets.InventorySystem
{
    public class EquipmentController : MonoBehaviour
    {
        [SerializeField] GameObject slot;
        [SerializeField] SlotController[] slots;

        void Start() {
            BuildContent();
        }
        protected void BuildContent() {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(slot, transform).SetActive(true);
            }
            slots = GetComponentsInChildren<SlotController>();
        }
    }
}

