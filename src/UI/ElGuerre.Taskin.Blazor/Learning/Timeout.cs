// ---------------------------------------------------------------------------------
// <copyright file="Timeout.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System;

namespace ElGuerre.Taskin.Blazor.Learning
{
    public static class Timeout
    {
        // https://github.com/aspnet/Blazor.Docs/issues/59
        // Must be static, non-generic, must not be overloaded and 
        // all the method parameters must be concrete types and deserializable using JSON
        public static void TimeoutCallback()
        {
            Console.WriteLine("Timeout triggered from JavaScript!");
        }
    }
}
