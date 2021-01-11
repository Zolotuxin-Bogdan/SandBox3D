﻿using System.Collections.Generic;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Data_Models
{
    public class Block
    {
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public BlockType BlockTypeName { get; set; }
        public MaterialType BlockMaterialType { get; set; }
        public string BlockTexturePath { get; set; }
        public HashSet<BlockProperties> BlockProperties { get; set; } = new HashSet<BlockProperties>();
        public int BlockDurability { get; set; }
        public int BlockDigRate { get; set; }
        public int BlockDropId { get; set; }
        public int BlockDropMaxCount { get; set; }
    }
}
