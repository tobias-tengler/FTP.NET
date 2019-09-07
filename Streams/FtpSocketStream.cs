using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ftp.Net
{
    internal class FtpSocketStream : Stream
    {
        private Socket? _socket;
        private NetworkStream? _networkStream;
        private StreamReader? _streamReader;
        private StreamWriter? _streamWriter;

        private readonly Encoding _encoding = Encoding.UTF8;

        public override bool CanRead => _networkStream?.CanRead ?? false;

        public override bool CanSeek => false;

        public override bool CanWrite => _networkStream?.CanWrite ?? false;

        public override long Length => 0;

        public override long Position { get => BaseStream?.Position ?? 0; set => throw new InvalidOperationException(); }

        public bool Connected => _socket != null && _socket.Connected;

        private Stream? BaseStream => _networkStream;

        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
        {
            _socket?.SetSocketOption(optionLevel, optionName, optionValue);
        }

        #region Read
        public override int Read(byte[] buffer, int offset, int count)
        {
            return BaseStream?.Read(buffer, offset, count) ?? 0;
        }

        public override int Read(Span<byte> buffer)
        {
            return BaseStream?.Read(buffer) ?? 0;
        }

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken token = default)
        {
            if (BaseStream == null) return 0;

            return await BaseStream.ReadAsync(buffer, token);
        }

        public Task<string> ReadLineAsync()
        {
            if (_streamReader == null) throw new Exception();

            return _streamReader.ReadLineAsync();
        }
        #endregion

        #region Write
        public override void Write(byte[] buffer, int offset, int count)
        {
            BaseStream?.Write(buffer, offset, count);
        }

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            BaseStream?.Write(buffer);
        }

        public override async ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken token = default)
        {
            if (BaseStream == null) return;

            await BaseStream.WriteAsync(buffer, token);
        }

        public Task WriteLineAsync(ReadOnlyMemory<char> line, CancellationToken token = default)
        {
            if (_streamWriter == null) throw new Exception();

            return _streamWriter.WriteLineAsync(line, token);
        }
        #endregion

        public async Task<bool> ConnectAsync(IPAddress address, ushort port)
        {
            _socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                await _socket.ConnectAsync(address, port);

                if (!_socket.Connected) return false;

                _networkStream = new NetworkStream(_socket);
                _streamReader = new StreamReader(_networkStream, _encoding);
                _streamWriter = new StreamWriter(_networkStream, _encoding);

                return true;
            }
            catch (Exception)
            {
                _socket.Dispose();
            }

            return false;
        }

        public override void Flush()
        {
            if (BaseStream != null && Connected)
                BaseStream.Flush();
        }

        public override async ValueTask DisposeAsync()
        {
            if (_socket != null)
            {
                try
                {
                    if (_socket.Connected) _socket.Dispose();
                }
                finally
                {
                    _socket = null;
                }
            }

            if (_networkStream != null)
            {
                try
                {
                    await _networkStream.DisposeAsync();
                }
                finally
                {
                    _networkStream = null;
                }
            }

            if (_streamReader != null)
            {
                try
                {
                    _streamReader.Dispose();
                }
                finally
                {
                    _streamReader = null;
                }
            }

            if (_streamWriter != null)
            {
                try
                {
                    _streamWriter.Dispose();
                }
                finally
                {
                    _streamWriter = null;
                }
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new InvalidOperationException();
        }

        public override void SetLength(long value)
        {
            throw new InvalidOperationException();
        }
    }
}