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

        ValueTask<bool> ConnectAsync(IPAddress host, ushort port, FtpClientEncryptionLevel encryptionLevel, CancellationToken token = default);

        ValueTask DisconnectAsync(CancellationToken token = default);
    }
}