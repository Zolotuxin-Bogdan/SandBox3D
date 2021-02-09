using Assets.WorldGeneration;
using Assets.WorldGeneration.Implementations;
using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    public void GenerateWorld()
    {
        var inst = BlockInstanceManager.Instance;
        inst.GenerateWorld(new PerlinNoiseGeneration());
    }
}
