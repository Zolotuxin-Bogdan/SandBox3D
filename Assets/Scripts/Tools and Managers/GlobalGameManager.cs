using Assets.Scripts.Tools_and_Managers;
using Assets.StorageSystem.StorageProviders;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResourcePackManager.Instance.UnpackTextures();
        ResourcePackStorageProvider.Instance.CreateResourcePack();
    }
}
