using System.IO;
using Assets.Serializer;

namespace Assets.StorageSystem
{
    public class Storage
    {
        public void SaveData<T>(T data, string path)
        {
            var directoryName = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(Serializer.Serializer.SerializeToJson(data));
            }
        }

        public T LoadData<T>(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            using (var sr = new StreamReader(path))
            {
                var dataFromFile = sr.ReadLine();
                return Deserializer.DeserializeJson<T>(dataFromFile);
            }
        }
    }
}