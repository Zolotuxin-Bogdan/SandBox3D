using UnityEngine;

public class BundleLoader
{
    private AssetBundle _assetBundle;

    public AssetBundle LoadAssetBundle(string bundlePath)
    {
        _assetBundle = AssetBundle.LoadFromFile(bundlePath);
        if (_assetBundle != null)
        {
            return _assetBundle;
        }

        return null;
    }
}
