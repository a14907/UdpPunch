using Models;
using Models.Extension;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    public class ServerRunner : IServer
    {
        private IServerFront _serverFront;
        private Socket _socket;
        private ConnectStore _connectStore = new ConnectStore();

        public ServerRunner(IServerFront formServer, int port)
        {
            _serverFront = formServer;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
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
                        var baseinfo = command as BaseInfo;
                        if (baseinfo != null)
                        {
                            baseinfo.FromPublic = endpoint as IPEndPoint;
                            _connectStore.Update(baseinfo);
                        }
                        Task.Run(() =>
                        {
                            try
                            {
                                switch (command)
                                {
                                    case TryConnectClientCommand c:
                                        Handle(c);
                                        break;
                                    case ConnectServerCommand c:
                                        Handle(c);
                                        break;
                                    case GetAllUserCommand c:
                                        Handle(c);
                                        break;
                                    case GetUserInfoCommand c:
                                        Handle(c);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                _serverFront.ShowMsg(ex.ToString());
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    _serverFront.ShowMsg(ex.ToString());
                }
            }, TaskCreationOptions.LongRunning);
        }

        public Socket GetSocket()
        {
            return _socket;
        }

        public void Handle(ConnectServerCommand connectServerCommand)
        {
            _serverFront.ShowMsg($"客户端连接成功：{connectServerCommand.UserName},fromPrivate:{connectServerCommand.FromPrivate},frompublic:{connectServerCommand.FromPublic}");
            var response = new GetAllUserResponseCommand
            {
                UserInfos = _connectStore.GetAllUser()
            };
            foreach (var item in _connectStore.GetAllUser())
            {
                Send(response, item.FromPublic);
            }
        }

        public void Handle(GetAllUserCommand getAllUserCommand)
        {
            var data = _connectStore.GetAllUser();
            var response = new GetAllUserResponseCommand
            {
                UserInfos = data
            };
            Send(response, getAllUserCommand.FromPublic);
            _serverFront.ShowMsg($"发送全部用户数据{data.Count}条，到{getAllUserCommand.FromPublic}");
        }

        public void Handle(GetUserInfoCommand getUserInfoCommand)
        {
            var response = new GetUserInfoResponseCommand
            {
                UserInfo = _connectStore.GetByUserId(getUserInfoCommand.TargetUserId)
            };
            Send(response, getUserInfoCommand.FromPublic);
        }

        public void Handle(TryConnectClientCommand tryConnectClientCommand)
        {
            Send(tryConnectClientCommand);
            _serverFront.ShowMsg("开始进行中介操作");
        }

        public void Send(TryConnectClientCommand tryConnectClientCommand)
        {
            var r1 = new TryConnectClientResponseCommand
            {
                Target = _connectStore.GetByUserId(tryConnectClientCommand.UserId),
                From = _connectStore.GetByUserId(tryConnectClientCommand.Target.UserId),
                IsFromServer = true,
                IsFix = true
            };
            var buf = r1.Serialize();
            _socket.SendTo(buf, r1.From.FromPublic);
            _serverFront.ShowMsg($"通知{r1.From.FromPublic}进行操作，固定的");

            var r2 = new TryConnectClientResponseCommand
            {
                Target = _connectStore.GetByUserId(tryConnectClientCommand.Target.UserId),
                From = _connectStore.GetByUserId(tryConnectClientCommand.UserId),
                IsFromServer = true
            };
            var buf2 = r2.Serialize();
            _socket.SendTo(buf2, r2.From.FromPublic);
            _serverFront.ShowMsg($"通知{r2.From.FromPublic}进行操作，非固定的，猜测");
        }

        public void Send(GetAllUserResponseCommand getAllUserResponseCommand, EndPoint endPoint)
        {
            _socket.SendTo(getAllUserResponseCommand.Serialize(), endPoint);
        }

        public void Send(GetUserInfoResponseCommand getUserInfoResponseCommand, EndPoint endPoint)
        {
            _socket.SendTo(getUserInfoResponseCommand.Serialize(), endPoint);
        }
    }
}
