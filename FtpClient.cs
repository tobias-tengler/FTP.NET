using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ftp.Net
{
    public partial class FtpClient : IFtpClient
    {
        public FtpClient() { }

        public FtpClient(IFtpClientLogger? logger)
        {
            Logger = logger;
        }

        ~FtpClient()
        {
            Dispose();
        }

        public bool Connected => _stream?.Connected ?? false;

        public IFtpClientLogger? Logger { get; set; }
        public IPAddress? HostAddress { get; set; }
        public ushort HostPort { get; set; }
        public FtpClientCredentials? Credentials { get; set; }
        public int Timeout { get; set; }
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public FtpClientEncryptionLevel EncryptionLevel { get; set; }
    }
}