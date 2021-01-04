using System.Xml;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ConfigLoader
    {
        public static XmlDocument GetConfig()
        {
            TextAsset textAsset = (TextAsset)Resources.Load("App");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(textAsset.text);
            return xmldoc;
        }
    }
}
