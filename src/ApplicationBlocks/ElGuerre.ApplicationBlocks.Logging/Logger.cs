<<<<<<< HEAD
﻿using ElGuerre.ApplicationBlocks.Logging.Providers;

namespace ElGuerre.ApplicationBlocks.Logging
{
    public class Logger : ILogger
    {
        readonly ILogProvider _logProvider;

        public Logger(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public void Debug(string msg)
        {
            _logProvider.Debug(msg);
        }

        public void Error(string msg)
        {
            _logProvider.Error(msg);
        }

        public void Info(string msg)
        {
            _logProvider.Info(msg);
        }

        public void Warning(string msg)
        {
            _logProvider.Warning(msg);
        }

        public void Trace(string msg)
        {
            _logProvider.Trace(msg);
        }
    }
}
=======
﻿using ElGuerre.ApplicationBlocks.Logging.Providers;

namespace ElGuerre.ApplicationBlocks.Logging
{
    public class Logger : ILogger
    {
        readonly ILogProvider _logProvider;

        public Logger(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public void Debug(string msg)
        {
            _logProvider.Debug(msg);
        }

        public void Error(string msg)
        {
            _logProvider.Error(msg);
        }

        public void Info(string msg)
        {
            _logProvider.Info(msg);
        }

        public void Warning(string msg)
        {
            _logProvider.Warning(msg);
        }

        public void Trace(string msg)
        {
            _logProvider.Trace(msg);
        }
    }
}
>>>>>>> develop
