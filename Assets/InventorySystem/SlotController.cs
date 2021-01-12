using UnityEngine;
using UnityEngine.UI;
using Assets.InventorySystem.Items;
using TMPro;

namespace Assets.InventorySystem.Controllers
{
    public class SlotController : MonoBehaviour {
        
        public Image icon;

        public UIItem item;

        public void AddItem(UIItem item) {
            // if (item.name.Equals(this.item?.name)) {
            //     this.item.amount += item.amount;
            // }
            // else 
            //     this.item = item;

            icon.color = Color.red;
            //icon.sprite = item.icon;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            item = null;
            // icon.sprite = null;
            // icon.enabled = false;
        }

        public void SetItemAmount(int amount = 1) {
            throw new System.NotImplementedException();
        }

        public void SetToolTip(string data) {
            GUI.Label(new Rect(), data, GUI.tooltip);
        }
    }
}