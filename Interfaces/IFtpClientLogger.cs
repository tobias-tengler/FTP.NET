using System;

namespace Ftp.Net
{
    public interface IFtpClientLogger
    {
        void Log(FtpClientLogLevel logLevel, string message);

        void Log(FtpClientLogLevel logLevel, Exception exception);

        void Log(FtpClientLogLevel logLevel, string message, Exception exception);
    }
}