using Assets.InventorySystem.Items;
using UnityEngine;

public class SceneEditor
{

    MeshProvider meshLoader;
    public SceneEditor()
    {
        meshLoader = new MeshProvider();
    }

    public void AddItem(InventoryItem item)
    {
        if (item == null)
            throw new System.ArgumentNullException(nameof(item));

        var _item = new GameObject(item.name);
        _item.AddComponent<Rigidbody>();
        _item.AddComponent<MeshRenderer>();
        _item.AddComponent<Item>().item = item;
        _item.AddComponent<MeshFilter>().mesh = meshLoader.ImportMeshBySlug(item.slug) ?? 
            throw new System.Exception(
                $"MeshImportingError: Mesh by {nameof(item.slug)} not found!"
            );
    }

    public void AddItem(InventoryItem item, string name)
    {
        if (item == null)
            throw new System.ArgumentNullException(nameof(item));
        
        var _item = new GameObject(name);
        _item.AddComponent<Rigidbody>();
        _item.AddComponent<MeshRenderer>();
        _item.AddComponent<Item>().item = item;
        _item.AddComponent<MeshFilter>().mesh = meshLoader.ImportMeshBySlug(item.slug) ?? 
            throw new System.Exception(
                $"MeshImportingError: Mesh by {nameof(item.slug)} not found!"
            );
    }

    public void AddItem(InventoryItem item, Mesh mesh)
    {
        if (item == null)
            throw new System.ArgumentNullException(nameof(item));
        
        var _item = new GameObject(item.name);
        _item.AddComponent<Rigidbody>();
        _item.AddComponent<MeshRenderer>();
        _item.AddComponent<Item>().item = item;
        _item.AddComponent<MeshFilter>().mesh = mesh ?? 
            throw new System.ArgumentNullException(nameof(mesh));
    }
}
