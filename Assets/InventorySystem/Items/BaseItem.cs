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
        public bool stackable { get; set; }
        public bool craftable { get; set; }
        public bool transparent { get; set; }
        public bool unexploaded { get; set; }
        public bool flammable { get; set; }
    }
}