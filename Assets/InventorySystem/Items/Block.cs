using Assets.Scripts.Enums;

namespace Assets.InventorySystem.Items
{
    public class Block : BaseItem
    {
        public bool gravity { get; set; } = false;
        public bool luminosity { get; set; } = false;
        public Block(int amount, string slug, string name, bool isCraftable, bool IsTrasparent = false, bool isUnexploaded = false, bool isFlammable = true)
        {
            this.amount = amount;
            this.slug = slug;
            this.name = name;
            this.type = ItemType.Block;
            this.stackable = true;
            this.craftable = isCraftable;
            this.transparent = IsTrasparent;
            this.unexploaded = isUnexploaded;
            this.flammable = isFlammable;
        }
        public Block() { }
    }
}