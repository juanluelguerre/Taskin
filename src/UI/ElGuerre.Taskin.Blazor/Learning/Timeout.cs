using System;

namespace ElGuerre.Taskin.Blazor.Learning
{
    public class Timeout
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
