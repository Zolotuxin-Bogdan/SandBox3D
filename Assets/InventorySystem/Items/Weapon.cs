namespace Assets.InventorySystem.Items
{
    public class Weapon: BaseItem
    {
        public int durability { get; set; }
        public float attackDistance { get; set; }
        public int damage { get; set; }
        public float attackSpeed { get; set; }
    }
}