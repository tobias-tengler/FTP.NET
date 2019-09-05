using System;

namespace Ftp.Net
{
    public static class FtpClientLoggerExtensions
    {
        public static void LogTrace(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Trace, null, exception);

        public static void LogDebug(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Debug, null, exception);

        public static void LogInformation(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Information, null, exception);

        public static void LogWarning(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Warning, null, exception);

        public static void LogError(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Error, null, exception);

        public static void LogCritical(this IFtpClientLogger logger, Exception exception) => logger.Log(FtpClientLogLevel.Critical, null, exception);

        public static void LogTrace(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Trace, message, null);

        public static void LogDebug(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Debug, message, null);

        public static void LogInformation(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Information, message, null);

        public static void LogWarning(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Warning, message, null);

        public static void LogError(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Error, message, null);

        public static void LogCritical(this IFtpClientLogger logger, string message) => logger.Log(FtpClientLogLevel.Critical, message, null);

        public static void LogTrace(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Trace, message, exception);

        public static void LogDebug(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Debug, message, exception);

        public static void LogInformation(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Information, message, exception);

        public static void LogWarning(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Warning, message, exception);

        public static void LogError(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Error, message, exception);

        public static void LogCritical(this IFtpClientLogger logger, string message, Exception exception) => logger.Log(FtpClientLogLevel.Critical, message, exception);
    }
}