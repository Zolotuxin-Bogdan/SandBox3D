using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public int BlockId { get; set; }
    public string BlockName { get; set; }
    public BlockTypes BlockTypeName { get; set; }
    public Material BlockMaterial { get; set; }
    public HashSet<BlockProperties> BlockProperties { get; set; } = new HashSet<BlockProperties>();
}
