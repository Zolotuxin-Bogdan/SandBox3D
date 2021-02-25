using System;
using System.IO;
using Assets.WorldGeneration;
using Assets.WorldGeneration.Implementations;
using UnityEngine;

public class DebugHelper : MonoBehaviour
{

    public GameObject perlinPanel;
    private BlockInstanceManager inst;
    private Texture2D _blueNoiseTexture;
    void Start()
    {
    
        var generator = new PerlinNoiseGeneration();
        var perlinTexture = generator.GenerateTexture();
        var renderer = perlinPanel.GetComponent<Renderer>();
        renderer.material.SetTexture("_BaseMap", perlinTexture);
        inst = BlockInstanceManager.Instance;
        _blueNoiseTexture = perlinTexture;
        GenerateTreesMap(perlinTexture.width, perlinTexture.height);
    }

    public void GenerateWorld()
    {
        inst.GenerateWorld(new PerlinNoiseGeneration());
    }
    
    public void Combine()
    {
        inst.Combine();
    }

    public void GenerateTreesMap(int width, int height)
    {
        var treesMap = GameObject.CreatePrimitive(PrimitiveType.Plane);
        treesMap.transform.position = new Vector3(perlinPanel.transform.position.x * 1.5f,
            perlinPanel.transform.position.y, perlinPanel.transform.position.z);
        var generator = new BlueNoiseGeneration(width, height);
        var texture = generator.NoiseGen();
        var renderer = treesMap.GetComponent<Renderer>();
        renderer.material.SetTexture("_BaseMap", texture);
    }

    public void GenerateTree()
    {
        inst.GenerateTree(new StaticTree(), new Vector3(1, 1, 1));
    }
}
