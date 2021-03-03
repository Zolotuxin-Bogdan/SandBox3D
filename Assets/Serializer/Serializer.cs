using System.Text;
using Newtonsoft.Json;

namespace Assets.Serializer
{
    public static class Serializer
    {
        public static string SerializeToJson<T>(T obj) =>
            JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static byte[] SerializeToBytes(string obj) =>
            Encoding.UTF8.GetBytes(obj);
    }
}
