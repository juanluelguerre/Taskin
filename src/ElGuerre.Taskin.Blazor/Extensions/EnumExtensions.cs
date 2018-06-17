using System;
using System.Collections.Generic;
using System.Linq;

namespace ElGuerre.Taskin.Blazor.Extensions
{
    public static class EnumExtensions
    {
        // <summary>
        /// If an enum MyEnum is { a = 3, b = 5, c = 12 } then
        /// typeof(MyEnum).ToValueList<<int>>() will return [3, 5, 12]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumType"></param>
        /// <returns>List of values defined for enum constants</returns>
        public static IList<KeyValuePair<TValue, String>> ToValueList<TValue>(this Type enumType)
        {
            return Enum.GetNames(enumType)
                .Select(x => new KeyValuePair<TValue, String>((TValue)Enum.Parse(enumType, x), x ))
                .ToList();
        }
    }
}
