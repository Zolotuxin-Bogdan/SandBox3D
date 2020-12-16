using System.Collections.Generic;
using UnityEngine;

public class BlockTypeManager : MonoBehaviour
{
    public static BlockTypeManager Instance { get; private set; }

    //
    // Block Types
    //
    public GameObject SingleTextureBlock;

    private Dictionary<string, GameObject> _typeDictionary = new Dictionary<string, GameObject>();
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
        _typeDictionary.Add(BlockType.SingleTexture.ToString(), SingleTextureBlock);
    }
    public GameObject GetBlockTypeByName(string typeName)
    {
        var isContains = _typeDictionary.ContainsKey(typeName);
        if (!isContains)
        {
            return null;
        }
        return _typeDictionary[typeName];
    }
}
