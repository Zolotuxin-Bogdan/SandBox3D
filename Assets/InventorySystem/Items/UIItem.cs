namespace Assets.InventorySystem.Items
{
    [System.Serializable]
    public class UIItem {
        public int amount { get; set; } = 1;
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public UnityEngine.Sprite icon { get; set; } = null;
    }
}