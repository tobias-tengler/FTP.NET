using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ftp.Net
{
    public class FtpClient : IFtpClient
    {
        public FtpClient() { }

        public FtpClient(IFtpClientLogger logger)
        {
            Logger = logger;
        }

        ~FtpClient()
        {
            Dispose();
        }

        public bool Connected { get; }

        public IFtpClientLogger Logger { get; set; }
        public IPAddress HostAddress { get; set; }
        public ushort HostPort { get; set; }
        public FtpClientCredentials Credentials { get; set; }
        public int Timeout { get; set; }
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public FtpClientEncryptionLevel EncryptionLevel { get; set; }

        public bool Connect(IPAddress host, ushort port, FtpClientEncryptionLevel encryptionLevel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ConnectAsync(IPAddress host, ushort port, FtpClientEncryptionLevel encryptionLevel, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public void Disconnect()
        {
            throw new System.NotImplementedException();
        }

        public Task DisconnectAsync(CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}