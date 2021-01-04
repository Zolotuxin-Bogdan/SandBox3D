using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class BundleUnpacker
    {
        public string TextureDefaultPath = Directory.GetCurrentDirectory() + "/texturepacks/Default";

        private BundleLoader _bundleLoader = new BundleLoader();
        public void UnpackTextures()
        {
            var xmlConfig = ConfigLoader.GetConfig();
            var texturesPathNode = xmlConfig.SelectSingleNode("XML/Configuration/Path/Textures");
            var pathForUnpack = TextureDefaultPath;
            if (texturesPathNode != null)
            {
                pathForUnpack = texturesPathNode.InnerText;
            }
            var directoryPath = Directory.GetCurrentDirectory() + pathForUnpack;

            var bundlePathNode = xmlConfig.SelectSingleNode("XML/Bundle/Textures");
            var bundlePath = Directory.GetCurrentDirectory() + bundlePathNode.InnerText;
            var bundle = _bundleLoader.LoadAssetBundle(bundlePath);
            var textures = bundle.LoadAllAssets();
            foreach (var texture in textures)
            {
                var image = GetValidTexture((Texture2D) texture);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var savePath = directoryPath + "/" + texture.name + ".png";
                File.WriteAllBytes(savePath, image.EncodeToPNG());
                Debug.Log(savePath);
            }
        
        }

        private Texture2D GetValidTexture(Texture2D source)
        {
            RenderTexture renderTex = RenderTexture.GetTemporary(
                source.width,
                source.height,
                0,
                RenderTextureFormat.ARGB32,
                RenderTextureReadWrite.sRGB);

            Graphics.Blit(source, renderTex);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTex;
            Texture2D readableTexture = new Texture2D(source.width, source.height);
            readableTexture.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
            readableTexture.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTex);
            return readableTexture;
        }
    }
}
