using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
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
            //
            // DROP ITEM
            //
            SceneEditor.instance.AddItem(new BlockDto()
            {
                BlockId = BlockDropId,
                Position = transform.position
            });
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
