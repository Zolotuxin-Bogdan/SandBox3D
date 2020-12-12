using System;
using Assets.Scripts.UI;

namespace Assets.Scripts
{
    public class Converter
    {
        /// <summary>
        /// Get enum value by Id
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="id">enum value id</param>
        /// <returns><see cref="string"/> or <see cref="ArgumentOutOfRangeException"/>></returns>
        public static T FromIdToString<T>(int id)
        {
            var values = System.Enum.GetValues(typeof(T));
            if (id > values.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
                return (T)values.GetValue(id);
        }
    }
}