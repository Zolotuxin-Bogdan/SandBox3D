namespace Assets.InventorySystem.Items
{
    public class Block: InventoryItem
    {
        public bool destroyOnUse { get; set; }
        public bool isContainer { get; set; }
    }
}