// ---------------------------------------------------------------------------------
// <copyright file="AppSettings.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------

namespace ElGuerre.OneRest.Taskin.Api
{
    public class AppSettings
    {
        public string ServiceUrl { get; set; }
        public string ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
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
