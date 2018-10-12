// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using System;

namespace ElGuerre.ApplicationBlocks.Core.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _name;
        private readonly CustomLoggerSettings _config;

        public CustomLogger(string name, CustomLoggerSettings config)
        {
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                var msg = $"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}";


                var color = Console.ForegroundColor;
                Console.ForegroundColor = _config.Color;
                Console.WriteLine(msg);
                Console.ForegroundColor = color;
            }
        }
    }
}
