// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public static class SerilogHostBuilderExtensions
    {
        public static IHostBuilder UseSerilog(this IHostBuilder builder,
            Serilog.ILogger logger = null, bool dispose = false)
        {
            builder.ConfigureServices((context, collection) =>
                collection.AddSingleton<ILoggerFactory>(services => new SerilogLoggerFactory(logger, dispose)));
            return builder;
        }
    }
}
