using InventorySystem.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem.Controllers
{
    public class SlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
        
        public Image icon;

        public UIItem item;

        [SerializeField] GameObject tooltip;
        [SerializeField] GameObject textMeshPro;
        [SerializeField] GameObject progressBar;
        Rect rect;
        private void Awake() {
            rect = GetComponent<RectTransform>().rect;
            icon.enabled = false;
        }

        public void AddItem(UIItem item) {
            if (item.durability > 0)
                ShowDurability(item.durability);

            if (item.amount > 1)
                ShowAmount(item.amount);

            this.item = item;
            icon.sprite = item.icon;
            icon.enabled = true;
        }

        private void ShowAmount(int amount)
        {
            textMeshPro.GetComponent<TextMeshProUGUI>().text = amount.ToString();
            textMeshPro.SetActive(true);
        }

        private void ShowDurability(int durability)
        {
            progressBar.GetComponent<Slider>().value = durability;
            progressBar.SetActive(true);
        }

        public void ClearSlot()
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (item != null) {
                if (!string.IsNullOrEmpty(item.name)) {
                    if (!string.IsNullOrEmpty(item.description)) {
                        tooltip.GetComponent<RectTransform>().position = 
                            new Vector2(
                                Input.mousePosition.x + 70, 
                                Input.mousePosition.y + 10
                            );
                        
                        var labels = tooltip.GetComponentsInChildren<TextMeshProUGUI>();
                        labels[0].text = item.name;
                        labels[1].text = item.description;
                        
                        if (item.name.Length > item.description.Length) {
                            var size = tooltip.GetComponent<RectTransform>().sizeDelta;
                            size = new Vector2(size.x, item.name.Length * 8);
                            tooltip.GetComponent<RectTransform>().sizeDelta = size;
                        } else {
                            var size = tooltip.GetComponent<RectTransform>().sizeDelta;
                            size = new Vector2(size.x, item.description.Length * 8);
                            tooltip.GetComponent<RectTransform>().sizeDelta = size;
                        }
                    
                    } else {
                        tooltip.GetComponent<RectTransform>().position = 
                            new Vector2(
                                Input.mousePosition.x + 50, 
                                Input.mousePosition.y + 10
                            );
                    
                        var labels = tooltip.GetComponentsInChildren<TextMeshProUGUI>();
                        labels[0].text = item.name;
                        labels[1].text = null;

                        tooltip.GetComponent<RectTransform>().sizeDelta = new Vector2(item.name.Length * 7.6f, 20);
                    }
                    tooltip.SetActive(true);
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.SetActive(false);
        }
   }
}