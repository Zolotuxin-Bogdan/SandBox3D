using System.Text;
using Newtonsoft.Json;

public static class Deserializer
{
    public static T DeserializeJson<T>(string obj) =>
        JsonConvert.DeserializeObject<T>(obj);

    public static string DeserializeBytes(byte[] obj) =>
        Encoding.UTF8.GetString(obj);
}
