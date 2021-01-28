using System.Collections.Generic;
using Assets.InventorySystem.Enums;
using Assets.Scripts.Enums;

namespace InventorySystem.Items
{
    public class Block : BaseItem
    {
        public bool gravity { get; set; } = false;
        public bool luminosity { get; set; } = false;
        public Block(int amount, string slug, string name, HashSet<ItemProperties> itemProperties)
        {
            this.amount = amount;
            this.slug = slug;
            this.name = name;
            this.type = ItemType.Block;
            this.itemProperties = itemProperties;
        }
        public Block() { }
    }
}