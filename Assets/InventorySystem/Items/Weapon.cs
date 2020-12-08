namespace Assets.InventorySystem.Items
{
    public class Weapon: InventoryItem
    {
        public int durability { get; set; }
        public int damage { get; set; }
        public float attackSpeed { get; set; }
    }
}