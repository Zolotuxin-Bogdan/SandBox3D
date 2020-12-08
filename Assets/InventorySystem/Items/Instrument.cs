namespace Assets.InventorySystem.Items
{
    public class Instrument: InventoryItem
    {
        public int durability { get; set; }
        public int damage { get; set; }
        public int mineRate { get; set; }
        public float attackSpeed { get; set; }
        public float mineSpeed { get; set; }
    }
}