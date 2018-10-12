using System;
using System.IO;
using Serilog;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public class FileProvider : BaseProvider
    {
        readonly string _filePath;

        public FileProvider(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                _filePath = "Trace.log";
            else
            {
                _filePath = (!Path.HasExtension(filePath)) ? $"{filePath}.log" : filePath;
            }
        }              

        protected override LoggerConfiguration Config
        {
            get
            {
                return base.Config
                   .WriteTo.Async(w => w.RollingFile(
                       _filePath,
                       outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}",
                       flushToDiskInterval: TimeSpan.FromSeconds(1)));
            }
        }
    }
}
