namespace Ftp.Net
{
    public class FtpResponse
    {
        public FtpResponse()
        {

        }

        public FtpResponse(uint code)
        {
            Code = code;
        }

        public FtpResponse(uint code, string message) : this(code)
        {
            Message = message;
        }

        public uint Code { get; set; }

        public string? Message { get; set; }

        public string? Data { get; set; }

        public bool Success => Code >= 100 && Code < 400;
    }
}