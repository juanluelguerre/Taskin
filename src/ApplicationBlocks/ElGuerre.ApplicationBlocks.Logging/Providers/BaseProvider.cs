using Serilog;
using Serilog.Events;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public class BaseProvider
    {
        readonly LoggerConfiguration _logConfiguration;

        public BaseProvider()
        {
            _logConfiguration = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Error);
        }   

        protected virtual LoggerConfiguration Config
        {
            get { return _logConfiguration; }
        }
    }
}
