using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public class FileProvider : BaseProvider, ILogProvider
    {
        readonly Serilog.ILogger _logger;
        readonly string _filePath;

        public FileProvider(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                _filePath = "Trace.log";
            else
            {
                _filePath = (!Path.HasExtension(filePath)) ? $"{filePath}.log" : filePath;

            }

            _logger = Config
                .CreateLogger();
        }

        public FileProvider(IConfiguration config)
        {
            _logger = base.Config
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }

        protected override LoggerConfiguration Config
        {
            get
            {
                return base.Config
                           .WriteTo.RollingFile(
                               _filePath,                                                
                               flushToDiskInterval: TimeSpan.FromSeconds(1));
            }
        }
             
        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public void Error(string msg)
        {
            _logger.Error(msg);        }

        public void Info(string msg)
        {
            _logger.Information(msg);       
        }

        public void Warning(string msg)
        {
            _logger.Warning(msg);
        }

        public void Trace(string msg)
        {
            _logger.Verbose(msg);
        }
    }
}
