using System;
using System.IO;
using Assets.WorldGeneration;
using Assets.WorldGeneration.Implementations;
using UnityEngine;

public class DebugHelper : MonoBehaviour
{

    public GameObject perlinPanel;
    private BlockInstanceManager inst;
    void Start()
    {
    
        var generator = new PerlinNoiseGeneration();
        var perlinTexture = generator.GenerateTexture();
        var renderer = perlinPanel.GetComponent<Renderer>();
        renderer.material.SetTexture("_BaseMap", perlinTexture);
        inst = BlockInstanceManager.Instance;
    }

    public void GenerateWorld()
    {
        inst.GenerateWorld(new PerlinNoiseGeneration());
    }

    public void Combine()
    {
        inst.Combine();
    }

    public void GenerateTree()
    {
        inst.GenerateTree(new StaticTree(), new Vector3(1, 1, 1));
    }
}
