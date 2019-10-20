using Models;
using Models.Extension;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class ClientRunner : IClient
    {
        private readonly IClientFront _clientFront;
        private readonly IPEndPoint _clientEndPoint;
        private readonly IPEndPoint _serverEndPoint;
        private readonly Socket _socket;
        private readonly ConnectStore _connectStore = new ConnectStore();

        public ClientRunner(IClientFront formClient, IPEndPoint clientEndPoint, IPEndPoint serverEndPoint)
        {
            _clientFront = formClient;
            _clientEndPoint = clientEndPoint;
            _serverEndPoint = serverEndPoint;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.Bind(clientEndPoint);
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var buf = new byte[1024 * 500];
                    while (true)
                    {
                        EndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                        var len = _socket.ReceiveFrom(buf, ref endpoint);
                        var command = buf.Derialize(len);
                        Task.Run(() =>
                        {
                            try
                            {
                                switch (command)
                                {
                                    case GetAllUserResponseCommand c:
                                        Handle(c);
                                        break;
                                    case GetUserInfoResponseCommand c:
                                        Handle(c);
                                        break;
                                    case TryConnectClientResponseCommand c:
                                        Handle(c, endpoint);
                                        break;
                                    case MessageCommand<TextMessage> c:
                                        Handle(c);
                                        break;
                                    case MessageCommand<FileMessage> c:
                                        Handle(c);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                _clientFront.ShowMsg(ex.ToString());
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    _clientFront.ShowMsg(ex.ToString());
                }
            }, TaskCreationOptions.LongRunning);
        }

        public Socket GetSocket()
        {
            return _socket;
        }

        public void Handle(GetAllUserResponseCommand getAllUserCommand)
        {
            _connectStore.Update(getAllUserCommand.UserInfos);
            _clientFront.UpdateUserList(getAllUserCommand.UserInfos);
        }

        public void Handle(GetUserInfoResponseCommand getUserInfoCommand)
        {
            _connectStore.Update(getUserInfoCommand.UserInfo);
            _clientFront.UpdateUserList(_connectStore.GetAllUser());
        }

        public void Handle<T>(MessageCommand<T> messageCommand) where T : IMessage
        {
            if (messageCommand.Content.Type == MessageType.Text)
            {
                var c = messageCommand.Content as TextMessage;
                _clientFront.ShowMsg($"{messageCommand.UserName}:{c.Content}");
            }
        }

        public void Handle(TryConnectClientResponseCommand tryConnectClientResponseCommand, EndPoint endpoint)
        {
            if (tryConnectClientResponseCommand.IsFromServer)
            {
                tryConnectClientResponseCommand.IsFromServer = false;
                if (tryConnectClientResponseCommand.IsFix)
                {
                    var buf = tryConnectClientResponseCommand.Serialize();
                    for (int i = 0; i < 10; i++)
                    {
                        _socket.SendTo(buf, tryConnectClientResponseCommand.Target.FromPublic);
                        _clientFront.ShowMsg($"{_clientEndPoint}=>{tryConnectClientResponseCommand.Target.FromPublic}");
                        //_socket.SendTo(buf, tryConnectClientResponseCommand.Target.FromPrivate);
                    }
                }
                else
                {
                    var fromip = (IPEndPoint)tryConnectClientResponseCommand.Target.FromPublic;
                    var arr = fromip.Address.ToString().Split('.');
                    var baseip = $"{arr[0]}.{arr[1]}.{arr[2]}.";
                    var buf = tryConnectClientResponseCommand.Serialize();
                    var mid = int.Parse(arr[3]);
                    for (int i = Math.Max(1, mid - 10); i < Math.Min(255, mid + 10); i++)
                    {
                        var newip = new IPEndPoint(IPAddress.Parse(baseip + i), fromip.Port);
                        tryConnectClientResponseCommand.Target.FromPublic = newip;
                        _socket.SendTo(buf, newip);
                        _clientFront.ShowMsg($"{_clientEndPoint}=>{newip}");
                        //_socket.SendTo(buf, tryConnectClientResponseCommand.Target.FromPrivate);
                    }
                }

            }
            else
            {
                //客户端之间连接成功
                _clientFront.ClientConnectSuccess(tryConnectClientResponseCommand.From, endpoint);
            }

        }

        public void Send<T>(MessageCommand<T> messageCommand) where T : IMessage
        {
            _socket.SendTo(messageCommand.Serialize(), messageCommand.Target);
        }

        public void Send(TryConnectClientCommand tryConnectClientCommand)
        {
            var buf = tryConnectClientCommand.Serialize();
            _socket.SendTo(buf, _serverEndPoint);
        }

        public void Send(ConnectServerCommand connectServerCommand)
        {
            _socket.SendTo(connectServerCommand.Serialize(), _serverEndPoint);
        }

        public void Send(GetAllUserCommand getAllUserCommand)
        {
            _socket.SendTo(getAllUserCommand.Serialize(), _serverEndPoint);
        }

        public void Send(GetUserInfoCommand getUserInfoCommand)
        {
            _socket.SendTo(getUserInfoCommand.Serialize(), _serverEndPoint);
        }
    }
}
