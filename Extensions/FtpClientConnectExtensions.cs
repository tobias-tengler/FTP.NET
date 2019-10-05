using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Ftp.Net
{
    public static class FtpClientConnectExtensions
    {
        public static ValueTask<bool> ConnectAsync(this IFtpClient ftpClient, CancellationToken token = default)
        {
            return ftpClient.ConnectAsync(ftpClient.HostAddress, ftpClient.HostPort, ftpClient.EncryptionLevel, token);
        }

        public static async ValueTask<bool> ConnectAsync(this IFtpClient ftpClient, Uri uri, CancellationToken token = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            var (hostName, address, port, encryptionLevel) = GetDetailsFromUri(uri);

            if (address != null && await ftpClient.ConnectAsync(address, port, encryptionLevel, token)) return true;

            var hostAddresses = Dns.GetHostAddresses(hostName);

            foreach (var hostAddress in hostAddresses)
                if (await ftpClient.ConnectAsync(hostAddress, port, encryptionLevel, token)) return true;

            return false;
        }

        private static (string hostName, IPAddress? address, ushort port, FtpEncryptionLevel encryptionLevel) GetDetailsFromUri(Uri uri)
        {
            return (uri.DnsSafeHost, GetIPAddressFromUri(uri), GetPortFromUri(uri), GetEncryptionLevelFromUri(uri));
        }

        private static IPAddress? GetIPAddressFromUri(Uri uri)
        {
            return IPAddress.TryParse(uri.DnsSafeHost, out var address) ? address : null;
        }

        private static ushort GetPortFromUri(Uri uri)
        {
            return (ushort)uri.Port;
        }

        private static FtpEncryptionLevel GetEncryptionLevelFromUri(Uri uri)
        {
            return uri.Scheme switch
            {
                "ftps" => FtpEncryptionLevel.Implicit,
                "ftpes" => FtpEncryptionLevel.Explicit,
                _ => FtpEncryptionLevel.None
            };
        }
    }
}