using System.Net;
using System.Text;

namespace Ftp.Net
{
    public interface IFtpClientOptions
    {
        IPAddress? HostAddress { get; set; }

        ushort HostPort { get; set; }

        FtpCredentials? Credentials { get; set; }

        int Timeout { get; set; }

        Encoding Encoding { get; set; }

        FtpEncryptionLevel EncryptionLevel { get; set; }
    }
}