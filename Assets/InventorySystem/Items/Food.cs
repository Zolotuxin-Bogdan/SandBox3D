namespace Assets.InventorySystem.Items
{
    public class Food: InventoryItem
    {
        public bool destroyOnUse { get; set; }
        public int satiety { get; set; }
    }
}