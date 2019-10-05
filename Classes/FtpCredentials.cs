namespace Ftp.Net
{
    public class FtpCredentials
    {
        public FtpCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}