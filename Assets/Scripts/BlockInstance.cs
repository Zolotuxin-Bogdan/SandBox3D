using UnityEngine;

public class BlockInstance : MonoBehaviour
{
    public int BlockId { get; set; }
    public int BlockDurability { get; set; }
    public int MaxBlockDurability { get; set; }
    public int BlockDropId { get; set; }

    void Start()
    {
        BlockDurability = MaxBlockDurability;
    }
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
    }
}
