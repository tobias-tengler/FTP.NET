using System;

namespace Ftp.Net
{
    public static class FtpClientLoggerExtensions
    {
        public static void LogTrace(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Trace, exception);

        public static void LogDebug(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Debug, exception);

        public static void LogInformation(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Information, exception);

        public static void LogWarning(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Warning, exception);

        public static void LogError(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Error, exception);

        public static void LogCritical(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Critical, exception);

        public static void LogTrace(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Trace, message);

        public static void LogDebug(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Debug, message);

        public static void LogInformation(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Information, message);

        public static void LogWarning(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Warning, message);

        public static void LogError(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Error, message);

        public static void LogCritical(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Critical, message);

        public static void LogTrace(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Trace, message, exception);

        public static void LogDebug(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Debug, message, exception);

        public static void LogInformation(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Information, message, exception);

        public static void LogWarning(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Warning, message, exception);

        public static void LogError(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Error, message, exception);

        public static void LogCritical(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Critical, message, exception);
    }
}