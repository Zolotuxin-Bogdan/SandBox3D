using Assets.Scripts.Enums;

namespace Assets.Scripts
{
    public class Item
    {
        // slug
        public string Slug { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int maxCount { get; set; }
        public string description { get; set; }
        public ItemType type { get; set; }
    }
}