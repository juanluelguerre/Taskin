using System;
namespace ElGuerre.ApplicationBlocks.Logging.Providers
{
    public interface ILogProvider
    {
        void Info(string msg);
        void Error(string msg);
        void Warning(string msg);
        void Debug(string msg);
        void Trace(string msg);
    }
}
