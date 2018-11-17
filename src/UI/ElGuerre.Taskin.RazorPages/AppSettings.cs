// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System;
namespace ElGuerre.Taskin.RazorPages
{
    public class AppSettings
    {
        public Connectionstrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public bool UseCustomizationData { get; set; }
        public string ServiceBaseUrl { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }

        public string ConvergenceConection { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
