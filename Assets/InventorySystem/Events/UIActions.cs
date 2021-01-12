namespace Assets.InventorySystem.Events
{
    public delegate void InventoryAction();
    public delegate void InventoryAction<T>(T value);
}