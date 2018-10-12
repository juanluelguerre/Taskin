// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System.Net.Http;
using System.Text;

namespace ElGuerre.Taskin.Blazor.Utils
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(Microsoft.JSInterop.Json.Serialize(obj), Encoding.UTF8, "application/json")
        {
        }
    }
}
