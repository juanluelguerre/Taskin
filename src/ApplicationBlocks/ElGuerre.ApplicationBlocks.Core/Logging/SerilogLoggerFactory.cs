// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using Serilog.Debugging;
using Seri = Serilog.Extensions.Logging;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly Seri.SerilogLoggerProvider _provider;

        public SerilogLoggerFactory(Serilog.ILogger logger = null, bool dispose = false)
        {
            _provider = new Seri.SerilogLoggerProvider(logger, dispose);
        }

        public void Dispose() => _provider.Dispose();

        public ILogger CreateLogger(string categoryName)
        {
            return _provider.CreateLogger(categoryName);
        }

        public void AddProvider(ILoggerProvider provider)
        {
            // Only Serilog provider is allowed!
            SelfLog.WriteLine("Ignoring added logger provider {0}", provider);
        }
    }
}
