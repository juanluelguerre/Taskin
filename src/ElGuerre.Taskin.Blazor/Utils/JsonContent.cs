using Microsoft.AspNetCore.Blazor;
using System.Net.Http;
using System.Text;

namespace ElGuerre.Taskin.Blazor.Utils
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonUtil.Serialize(obj), Encoding.UTF8, "application/json")
        {
        }
    }
}
