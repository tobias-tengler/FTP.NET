using System;

namespace Ftp.Net
{
    public static class FtpClientLoggerExtensions
    {
        public static void LogTrace(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpLogLevel.Trace, exception);

        public static void LogDebug(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpLogLevel.Debug, exception);

        public static void LogInformation(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpLogLevel.Information, exception);

        public static void LogWarning(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpLogLevel.Warning, exception);

        public static void LogError(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpLogLevel.Error, exception);

        public static void LogCritical(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpLogLevel.Critical, exception);

        public static void LogTrace(this IFtpClientLogger logger, string message) => logger.Log(FtpLogLevel.Trace, message);

        public static void LogDebug(this IFtpClientLogger logger, string message) => logger.Log(FtpLogLevel.Debug, message);

        public static void LogInformation(this IFtpClientLogger logger, string message) => logger.Log(FtpLogLevel.Information, message);

        public static void LogWarning(this IFtpClientLogger logger, string message) => logger.Log(FtpLogLevel.Warning, message);

        public static void LogError(this IFtpClientLogger logger, string message) => logger.Log(FtpLogLevel.Error, message);

        public static void LogCritical(this IFtpClientLogger logger, string message) => logger.Log(FtpLogLevel.Critical, message);

        public static void LogTrace(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpLogLevel.Trace, message, exception);

        public static void LogDebug(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpLogLevel.Debug, message, exception);

        public static void LogInformation(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpLogLevel.Information, message, exception);

        public static void LogWarning(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpLogLevel.Warning, message, exception);

        public static void LogError(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpLogLevel.Error, message, exception);

        public static void LogCritical(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpLogLevel.Critical, message, exception);
    }
}