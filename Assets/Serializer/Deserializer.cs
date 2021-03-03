using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Assets.Serializer
{
    public static class Deserializer
    {
        public static T DeserializeJson<T>(string obj) =>
            JsonConvert.DeserializeObject<T>(obj);

        public static T DeserializeJson<T>(StreamReader streamReader)
        {
            JsonSerializer serializer = new JsonSerializer();
            var data = serializer.Deserialize(streamReader, typeof(T));
            return (T) data;
        }

        public static string DeserializeBytes(byte[] obj) =>
            Encoding.UTF8.GetString(obj);
    }
}
