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
        Test_BlueNoiseHighMapGeneration(perlinTexture);
    }

    public void GenerateWorld()
    {
        inst.GenerateWorld(new PerlinNoiseGeneration());
    }

    public void GenerateBNWorld()
    {
        inst.GenerateWorld(new BlueNoiseGeneration(_blueNoiseTexture.width, _blueNoiseTexture.height, _blueNoiseTexture));
    }

    public void Combine()
    {
        inst.Combine();
    }

    public void Test_BlueNoiseHighMapGeneration(Texture2D noise)
    {
        var blueNoisePanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
        blueNoisePanel.transform.position = new Vector3(perlinPanel.transform.position.x * 1.5f,
            perlinPanel.transform.position.y, perlinPanel.transform.position.z);
        var generator = new BlueNoiseGeneration(noise.width, noise.height, noise);
        var blueNoiseTex = generator.GenerateBlueNoise();
        var renderer = blueNoisePanel.GetComponent<Renderer>();
        renderer.material.SetTexture("_BaseMap", blueNoiseTex);
        Test_BlueNoiseGeneration(blueNoiseTex);
    }

    public void Test_BlueNoiseGeneration(Texture2D noise)
    {
        var blueNoisePanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
        blueNoisePanel.transform.position = new Vector3(perlinPanel.transform.position.x * 2.2f,
            perlinPanel.transform.position.y, perlinPanel.transform.position.z);
        var generator = new BlueNoiseGeneration(noise.width, noise.height, noise);
        var blueNoiseTex = generator.GenerateTexture();
        var renderer = blueNoisePanel.GetComponent<Renderer>();
        renderer.material.SetTexture("_BaseMap", blueNoiseTex);
    }

    public void GenerateTree()
    {
        inst.GenerateTree(new StaticTree(), new Vector3(1, 1, 1));
    }
}
