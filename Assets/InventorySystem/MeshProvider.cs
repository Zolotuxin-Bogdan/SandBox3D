using UnityEngine;

namespace Assets.InventorySystem
{
    public class MeshProvider
    {
        public Mesh ImportMeshBySlug(string slug)
        {
            return (Mesh)Resources.Load<Mesh>(slug) ?? throw new System.Exception("Failed to load Mesh");
        }
    }
}
