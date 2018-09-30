// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.JSInterop;
using System;

namespace ElGuerre.Taskin.Blazor.Learning
{
    public class TimeoutHelper
    {
        public TimeoutHelper(int timeout)
        {
            TimeOut = timeout;
        }

        public int TimeOut { get; set; }

        [JSInvokable]
        public string PrintTimeOut()
        {
            string msg = $"Timeout in {TimeOut}";
            // Console.WriteLine(msg);
            return msg;
        }
    }
}
