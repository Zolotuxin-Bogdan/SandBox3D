using System.Collections;
using System.Collections.Generic;
using Assets.InventorySystem.Controllers;
using UnityEngine;

namespace Assets.InventorySystem
{
    public class HotBarController : MonoBehaviour
    {
        [SerializeField] GameObject slot;
        [SerializeField] SlotController[] slots;
        [SerializeField] readonly int SLOTS_COUNT;

        protected void Awake() {
            
        }

        protected void BuildContent() {
            for (int i = 0; i < SLOTS_COUNT; i++)
            {
                Instantiate(slot, transform).SetActive(true);
            }
            slots = GetComponentsInChildren<SlotController>();
        }

        protected void UpdateUI() {

        }
    }
}

