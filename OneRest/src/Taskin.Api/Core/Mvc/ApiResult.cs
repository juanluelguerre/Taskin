// ---------------------------------------------------------------------------------
// <copyright file="ApiResult.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace ElGuerre.OneRest.Taskin.Api.Core.Mvc
{
    public class ApiResult<T>
    {
        public bool ResultValid { get; set; }
        public string ResultCode { get; set; }
        public T Data { get; set; }
    }
}
