using System.Net;
using System.Text;

namespace Ftp.Net
{
    public interface IFtpClientOptions
    {
        IPAddress? HostAddress { get; set; }

        ushort HostPort { get; set; }

        FtpClientCredentials? Credentials { get; set; }

        int Timeout { get; set; }

        Encoding Encoding { get; set; }

        FtpClientEncryptionLevel EncryptionLevel { get; set; }
    }
}