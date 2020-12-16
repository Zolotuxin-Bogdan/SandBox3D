using System.Collections.Generic;

public class Block
{
    public int BlockId { get; set; }
    public string BlockName { get; set; }
    public BlockType BlockTypeName { get; set; }
    public MaterialType BlockMaterialType { get; set; }
    public string BlockTexturePath { get; set; }
    public HashSet<BlockProperties> BlockProperties { get; set; } = new HashSet<BlockProperties>();
}
