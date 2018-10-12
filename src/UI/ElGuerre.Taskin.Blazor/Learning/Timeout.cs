// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.JSInterop;

namespace ElGuerre.Taskin.Blazor.Learning
{

    /// <summary>
    /// Sample static Class to be called directly from Javascript code.
    /// </summary>
    public static class StaticTimeOutHelper
    {
        // Method must be named different from others [JSInvocable] methods.
        [JSInvokable]
        public static string StaticPrintTimeOut(/* int timeout */)
        {
            int timeout = 5;

            string msg = $"Timeout in {timeout}";
            return msg;
        }
    }

    /// <summary>
    /// Non static class to be called from Javascript using intermediate C# method 
    /// like this(found inside Learning.cshtml):
    /// <code>
    ///     public static Task PrintTimeOut()
    ///     {
    ///     int timeOut = 5;
    ///     
    ///         return JSRuntime.Current.InvokeAsync<object>(
    ///             "simpleTimeOut.run",
    ///     new DotNetObjectRef(new TimeoutHelper(timeOut)));
    ///     }
    /// </code>
    /// </summary>
    public class TimeoutHelper
    {
        public TimeoutHelper(int timeout)
        {
            TimeOut = timeout;
        }

        public int TimeOut { get; set; }

        // Method must be named different from others [JSInvocable] methods.
        [JSInvokable]
        public string PrintTimeOut()
        {
            string msg = $"Timeout in {TimeOut}";
            // Console.WriteLine(msg);
            return msg;
        }
    }
}
