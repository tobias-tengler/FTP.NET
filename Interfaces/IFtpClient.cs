using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Ftp.Net
{
    public interface IFtpClient : IDisposable, IAsyncDisposable, IFtpClientOptions
    {
        bool Connected { get; }

        IFtpClientLogger Logger { get; set; }

        bool Connect(IPAddress host, ushort port, FtpClientEncryptionLevel encryptionLevel);

        Task<bool> ConnectAsync(IPAddress host, ushort port, FtpClientEncryptionLevel encryptionLevel, CancellationToken token = default);

        void Disconnect();

        Task DisconnectAsync(CancellationToken token = default);
    }
}