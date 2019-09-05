using System;

namespace Ftp.Net
{
    public interface IFtpClientLogger
    {
        void Log(FtpClientLogLevel logLevel, string message, Exception exception);
    }
}