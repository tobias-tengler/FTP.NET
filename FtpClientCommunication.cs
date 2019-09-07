using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ftp.Net
{
    public partial class FtpClient
    {
        private FtpSocketStream? _stream;

        public async ValueTask<bool> ConnectAsync(IPAddress? host, ushort port, FtpClientEncryptionLevel encryptionLevel, CancellationToken token = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (_stream != null) return false;

            _stream = new FtpSocketStream();

            await _stream.ConnectAsync(host, port);

            _stream.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

            var handShakeResp = await GetResponseAsync();

            if (!handShakeResp.Success) return false;

            if (Credentials != null && !await AuthenticateAsync(Credentials.Username, Credentials.Password, token))
                return false;

            return true;
        }

        public async ValueTask DisconnectAsync(CancellationToken token = default)
        {
            if (_stream == null || !_stream.Connected) return;

            try
            {
                await SendAsync(FtpCommands.Quit.AsMemory(), token);
            }
            finally
            {
                _stream.Close();
                _stream = null;
            }
        }

        private async Task<bool> AuthenticateAsync(string username, string password, CancellationToken token = default)
        {
            var usernameResp = await SendAsync(FtpCommands.Username, username, token);

            if (!usernameResp.Success) return false;

            var passwordResp = await SendAsync(FtpCommands.Password, password, token);

            return passwordResp.Success;
        }

        private Task<FtpResponse> SendAsync(string command, string parameter, CancellationToken token = default)
        {
            return SendAsync($"{command} {parameter}".AsMemory(), token);
        }

        private async Task<FtpResponse> SendAsync(ReadOnlyMemory<char> command, CancellationToken token = default)
        {
            if (_stream == null) throw new Exception();

            if (!Connected)
            {
                if (command.Equals(FtpCommands.Quit)) return new FtpResponse(200);

                if (!await this.ConnectAsync(token)) throw new Exception();
            }

            await _stream.WriteLineAsync(command, token);

            return await GetResponseAsync();
        }

        private async Task<FtpResponse> GetResponseAsync()
        {
            if (_stream == null) throw new Exception();

            var resp = new FtpResponse();
            var data = new StringBuilder();

            string buffer;

            // todo no regex
            while ((buffer = await _stream.ReadLineAsync()) != null)
            {
                var match = Regex.Match(buffer, @"^(?<code>[0-9]{3})(?<separator>.{1})(?<message>.*)$");

                if (match.Success)
                {
                    uint.TryParse(match.Groups["code"].Value, out var code);
                    var message = match.Groups["message"].Value;

                    resp.Code = code;
                    resp.Message = message;

                    var separator = match.Groups["separator"].Value;

                    if (separator == " ") break;
                }
                else
                {
                    data.AppendLine(buffer.Trim());
                }
            }

            if (resp == null) throw new Exception();

            resp.Data = data.ToString();

            return resp;
        }

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }

        public async ValueTask DisposeAsync()
        {
            if (_stream == null) return;

            if (_stream.Connected) await DisconnectAsync();

            try
            {
                await _stream.DisposeAsync();
            }
            finally
            {
                _stream = null;
            }
        }
    }
}