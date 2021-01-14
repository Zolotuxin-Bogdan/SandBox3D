using System.Collections.Generic;
using Assets.Scripts.Enums;

namespace Assets.InventorySystem.Items
{
    [System.Serializable]
    public class BaseItem {
        public int amount { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int id { get; set; }
        public ItemType type { get; set; }
        public HashSet<ItemProperties> itemProperties { get; set; } = new HashSet<ItemProperties>();
    }
}