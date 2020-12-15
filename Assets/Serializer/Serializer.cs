using Newtonsoft.Json;

public static class Serializer
{
    public static string SerializeToJson<T>(T obj) =>
        JsonConvert.SerializeObject(obj);
}
