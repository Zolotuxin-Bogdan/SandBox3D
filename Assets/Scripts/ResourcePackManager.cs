using System.IO;
using UnityEngine;

public class ResourcePackManager : MonoBehaviour
{
    public static ResourcePackManager Instance { get; private set; }

    
    //
    // Materials
    //
    public Material cobblestoneMaterial;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    

    public ResourcePack CreateResourcePack()
    {
        var resourcePack = new ResourcePack();
        var cobblestone = new Block()
        {
            BlockId = 0,
            BlockName = "Cobblestone",
            BlockTypeName = BlockTypes.SingleTexture,
            BlockMaterial = cobblestoneMaterial
        };
        resourcePack.Blocks.Add(cobblestone);

        return resourcePack;
    }
}
