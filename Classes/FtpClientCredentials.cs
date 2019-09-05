namespace Ftp.Net
{
    public class FtpClientCredentials
    {
        public FtpClientCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}