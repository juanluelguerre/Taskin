using Microsoft.Extensions.Configuration;
using Serilog;

namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public class LogProvider : BaseProvider
    {
        IConfiguration _config;

        public LogProvider(IConfiguration config)
        {
            _config = config;
        }
        protected override LoggerConfiguration Config => base.Config.ReadFrom.Configuration(_config);
    }
}
