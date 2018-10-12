// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ElGuerre.ApplicationBlocks.Core.Session.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value) =>
            session.SetString(key, JsonConvert.SerializeObject(value));

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
