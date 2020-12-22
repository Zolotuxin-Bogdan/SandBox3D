using System.Collections.Generic;
using UnityEngine;

public class BlockMaterialManager : MonoBehaviour
{
    public static BlockMaterialManager Instance { get; private set; }

    //
    // Material Types
    //
    public Material FullSizeBlockMaterial;

    private Dictionary<string, Material> _materialDictionary = new Dictionary<string, Material>();
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
    void Start()
    {
        _materialDictionary.Add(MaterialType.FullSizeBlockMaterial.ToString(), FullSizeBlockMaterial);
    }
    public Material GetBlockMaterialByName(string typeName)
    {
        var isContains = _materialDictionary.ContainsKey(typeName);
        if (!isContains)
        {
            return null;
        }
        return _materialDictionary[typeName];
    }
}
