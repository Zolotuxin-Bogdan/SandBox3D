using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Tools_and_Managers;

namespace Assets.LocalizationSystem
{
    public class LocalizationSystem
    {
        public static Languages Language; 

        private static Dictionary<string, string> localizedEN;
        private static Dictionary<string, string> localizedRU;

        public static bool IsInit;

        public static void Init()
        {
            Language = SettingsManager.Instance.GetSettings().language;

            CSVLoader csvLoader = new CSVLoader();
            csvLoader.LoadCSV();

            localizedEN = csvLoader.GetDictionaryValues("en");
            localizedRU = csvLoader.GetDictionaryValues("ru");

            IsInit = true;
        }

        public static string GetLocalizedValue(string key)
        {
            if (!IsInit)
            {
                Init();
            }

            string value = key;

            switch (Language)
            {
                case Languages.English:
                    localizedEN.TryGetValue(key, out value);
                    break;
                case Languages.Russian:
                    localizedRU.TryGetValue(key, out value);
                    break;
            }

            return value;
        }

        public static void ChangeCurrentLanguage(Languages language)
        {
            Language = language;
        }
    }
}
