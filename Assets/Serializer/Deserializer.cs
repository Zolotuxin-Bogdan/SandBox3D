using Newtonsoft.Json;

public static class Deserializer
{
    public static T DeserializeJson<T>(string obj) =>
        JsonConvert.DeserializeObject<T>(obj);
}
