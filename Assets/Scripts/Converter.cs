using System;

namespace Assets.Scripts
{
    public class Converter
    {
        /// <summary>
        /// Get enum value by Id
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="id">enum value id</param>
        /// <returns><see cref="string"/></returns>
        public static string FromIdToString<T>(int id)
        {
            var names = Enum.GetNames(typeof(T));
            return names[id];
        }
    }
}