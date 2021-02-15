using System;
using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
using Assets.WorldGeneration;
using UnityEngine;

namespace Assets.Scripts
{
    public class BlockInstance : MonoBehaviour
    {
        public int BlockId { get; set; }
        public int BlockDurability { get; set; }
        public int MaxBlockDurability { get; set; }
        public int BlockDropId { get; set; }
        public int BlockDropMaxCount { get; set; }

        public void RestoreMaxDurability()
        {
            BlockDurability = MaxBlockDurability;
        }

        public void RemoveDurability(int value)
        {
            BlockDurability -= value;
            if (BlockDurability <= 0)
            {
                OnBlockDestroy();
            }
        }

        private void OnBlockDestroy()
        {
            Destroy(gameObject);
            var currentBlockDto = new BlockDto()
            {
                BlockId = BlockDropId,
                Position = transform.position
            };
            //
            // DROP ITEM
            //
            ItemSpawner.instance.AddItem(currentBlockDto);

            BlockInstanceManager.Instance.CreateSurroundBlocksIfPossible(currentBlockDto);
        }

        public void SetDefaultValues(Block blockInfo)
        {
            BlockId = blockInfo.BlockId;
            BlockDurability = blockInfo.BlockDurability;
            MaxBlockDurability = blockInfo.BlockDurability;
            BlockDropId = blockInfo.BlockDropId;
            BlockDropMaxCount = blockInfo.BlockDropMaxCount;
        }
    }
}
