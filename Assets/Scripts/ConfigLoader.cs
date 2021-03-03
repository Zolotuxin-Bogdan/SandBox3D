using System.Xml;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ConfigLoader
    {
        public static XmlDocument GetConfig()
        {
#if UNITY_EDITOR
            TextAsset textAsset = (TextAsset)Resources.Load("App_Debug");
#else
            TextAsset textAsset = (TextAsset)Resources.Load("App_Release");
#endif
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(textAsset.text);
            return xmldoc;
        }
    }
}
