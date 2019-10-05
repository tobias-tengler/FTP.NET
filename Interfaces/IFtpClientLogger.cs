using System;

namespace Ftp.Net
{
    public interface IFtpClientLogger
    {
        void Log(FtpLogLevel logLevel, string message);

        void Log(FtpLogLevel logLevel, Exception exception);

        void Log(FtpLogLevel logLevel, string message, Exception exception);
    }
}