using System.Text;
using Newtonsoft.Json;

public static class Serializer
{
    public static string SerializeToJson<T>(T obj) =>
        JsonConvert.SerializeObject(obj);

    public static byte[] SerializeToBytes(string obj) =>
        Encoding.UTF8.GetBytes(obj);
}
