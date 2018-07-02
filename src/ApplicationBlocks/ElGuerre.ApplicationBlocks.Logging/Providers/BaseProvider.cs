using Serilog;
using Serilog.Events;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public class BaseProvider : ILogProvider
    {
        readonly LoggerConfiguration _logConfiguration;
        Serilog.ILogger _logger;

        public BaseProvider()
        {
            _logConfiguration = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Error);

            _logger = null;
        }

        protected virtual LoggerConfiguration Config
        {
            get { return _logConfiguration; }
        }

        public Serilog.ILogger Logger
        {
            get
            {
                if (_logger == null) 
                    _logger = Config.CreateLogger();
                return _logger;
            }
        }

        public void Debug(string msg)
        {
            if (Logger.IsEnabled(LogEventLevel.Debug))
                Logger.Debug(msg);
        }

        public void Error(string msg)
        {
            if (Logger.IsEnabled(LogEventLevel.Error))
                Logger.Error(msg);
        }

        public void Info(string msg)
        {
            if (Logger.IsEnabled(LogEventLevel.Information))
                Logger.Information(msg);
        }

        public void Warning(string msg)
        {
            if (Logger.IsEnabled(LogEventLevel.Warning))
                Logger.Warning(msg);
        }

        public void Trace(string msg)
        {
            if (Logger.IsEnabled(LogEventLevel.Verbose))
                Logger.Verbose(msg);
        }
    }
}
