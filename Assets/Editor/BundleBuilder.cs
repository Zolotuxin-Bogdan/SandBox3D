using UnityEditor;

namespace Assets.Editor
{
    public class BundleBuilder
    {
        [MenuItem("Assets/ Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles",
                BuildAssetBundleOptions.ChunkBasedCompression,
                EditorUserBuildSettings.activeBuildTarget);
        }
    }
}
