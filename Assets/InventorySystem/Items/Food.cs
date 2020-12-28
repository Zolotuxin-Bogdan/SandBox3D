namespace Assets.InventorySystem.Items
{
    public class Food: BaseItem
    {
        public bool destroyOnUse { get; set; }
        public int satiety { get; set; }
    }
}