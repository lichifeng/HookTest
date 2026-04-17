using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace AgeHood.HookTest
{
    public class TransferProxy
    {
        public enum ProxyState
        {
            Starting,
            Running,
            Stopped
        }

        private readonly TcpListener _tcpListener = new TcpListener(IPAddress.Loopback, 0); // 0: random available port
        private readonly TcpClient _tcpClient = new TcpClient();
        private readonly UdpClient _udpProxy = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        private NetworkStream _stream;
        // writer semaphore to serialize writes to the network stream
        private readonly SemaphoreSlim _writeSemaphore = new SemaphoreSlim(1, 1);
        private readonly ushort _udpProxyPort;
        private readonly ushort _tcpProxyPort;
        private uint _virtualIp;
        private ProxyState _state = ProxyState.Stopped;
        private string _remoteHost = "localhost";
        private int _remotePort = 52300;

        public TransferProxy()
        {
            _udpProxyPort = (ushort)(_udpProxy.Client.LocalEndPoint as IPEndPoint).Port;
            _tcpProxyPort = (ushort)(_tcpListener.LocalEndpoint as IPEndPoint).Port;
        }

        public ushort UdpProxyPort => _udpProxyPort;
        public ushort TcpProxyPort => _tcpProxyPort;
        public uint VirtualIp => _virtualIp;
        public ProxyState State => _state;

        public string RemoteHost
        {
            get => _remoteHost;
            set => _remoteHost = value;
        }

        public int RemotePort
        {
            get => _remotePort;
            set => _remotePort = value;
        }



        public async Task Start()
        {
            _state = ProxyState.Starting;
            try
            {
                // Connect without blocking caller
                await _tcpClient.ConnectAsync(_remoteHost, _remotePort);
                _stream = _tcpClient.GetStream();

                // Read 4 bytes virtual IP from stream asynchronously
                var vIpBuf = new byte[4];
                var read = 0;
                while (read < 4)
                {
                    var n = await _stream.ReadAsync(vIpBuf, read, 4 - read);
                    if (n == 0) throw new EndOfStreamException("Remote closed connection while reading virtual IP");
                    read += n;
                }
                // little-endian
                _virtualIp = (uint)(vIpBuf[0] | (vIpBuf[1] << 8) | (vIpBuf[2] << 16) | (vIpBuf[3] << 24));

                _tcpListener.Start();

                _ = UdpProxyLoop();
                _ = StreamLoop();
                _ = TcpProxyLoop();

                _state = ProxyState.Running;
            }
            catch
            {
                _state = ProxyState.Stopped;
                throw;
            }
        }

        public void Close()
        {
            _state = ProxyState.Stopped;
            // ensure stream closed
            _stream?.Close();
            if (_tcpClient != null && _tcpClient.Connected)
            {
                _tcpClient.Close();
            }

            _udpProxy?.Close();

            if (_tcpListener != null)
            {
                try
                {
                    if (_tcpListener.Server != null && _tcpListener.Server.IsBound)
                    {
                        _tcpListener.Stop();
                    }
                }
                catch
                {
                }
            }
        }

        private async Task UdpProxyLoop()
        {
            while (true)
            {
                var result = await _udpProxy.ReceiveAsync();
                var packet = result.Buffer;
                // Forward raw packet to remote over TCP stream
                if (_stream != null)
                {
                    await _writeSemaphore.WaitAsync();
                    try
                    {
                        await _stream.WriteAsync(packet, 0, packet.Length);
                        await _stream.FlushAsync();
                    }
                    finally
                    {
                        _writeSemaphore.Release();
                    }
                }
            }
        }

        private async Task StreamLoop()
        {
            var header = new byte[17];
            while (true)
            {
                // read exactly 17 bytes header
                var read = 0;
                while (read < 17)
                {
                    var n = await _stream.ReadAsync(header, read, 17 - read);
                    if (n == 0) throw new EndOfStreamException("Remote closed connection");
                    read += n;
                }

                var command = header[0];
                var fromVip = (uint)(header[1] | (header[2] << 8) | (header[3] << 16) | (header[4] << 24));
                var fromPort = (ushort)(header[5] | (header[6] << 8));
                var toVip = (uint)(header[7] | (header[8] << 8) | (header[9] << 16) | (header[10] << 24));
                var toPort = (ushort)(header[11] | (header[12] << 8));
                var length = header[13] | (header[14] << 8) | (header[15] << 16) | (header[16] << 24);

                var data = new byte[length];
                read = 0;
                while (read < length)
                {
                    var n = await _stream.ReadAsync(data, read, length - read);
                    if (n == 0) throw new EndOfStreamException("Remote closed connection while reading payload");
                    read += n;
                }

                var packet = new byte[length + 17];
                Buffer.BlockCopy(header, 0, packet, 0, 17);
                Buffer.BlockCopy(data, 0, packet, 17, length);

                switch (command)
                {
                    case 1://udp sendto
                        await _udpProxy.SendAsync(packet, packet.Length, new IPEndPoint(IPAddress.Loopback, toPort));
                        break;
                }
            }
        }

        private async Task TcpProxyLoop()
        {
            while (true)
            {
                await _tcpListener.AcceptTcpClientAsync();

            }
        }
    }
}
