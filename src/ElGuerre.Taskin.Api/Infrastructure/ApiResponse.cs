// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Newtonsoft.Json;

namespace ElGuerre.Taskin.Api
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            ErrorCode = "0000";
            ErrorMessage = string.Empty;
            Data = default;
        }

        public ApiResponse(T data) => Data = data;

        public bool IsValid { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this,
                 new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore });
        }
    }

    public class ApiResponse : ApiResponse<object>
    {
    }
}
