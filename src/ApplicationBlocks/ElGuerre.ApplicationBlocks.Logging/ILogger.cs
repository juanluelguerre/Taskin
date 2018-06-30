using System;
namespace ElGuerre.ApplicationBlocks.Logging
{
    public interface ILogger
    {
        void Info(string msg);
        void Error(string msg);
        void Warning(string msg);
        void Debug(string msg);
        void Trace(string msg);
    }
}
