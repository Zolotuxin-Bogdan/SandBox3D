namespace Assets.InventorySystem.Items
{
    [System.Serializable]    
    public class InventoryItem
    {
        public string slug {get; set;} = "";
        public string name {get; set;} = "";
        public string description {get; set;} = "";
        public bool isStackable {get; set;} = false;
        public UnityEngine.Sprite icon {get; set;} = null;
        public int count { get; set; } = 1;
        public int stackSize { get; set; } = 1;
        public bool isCraftable { get;set; } = false;
    }
}