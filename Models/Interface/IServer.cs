using System.Net;
using System.Net.Sockets;

namespace Models
{
    public interface IServer
    {
        void Handle(TryConnectClientCommand tryConnectClientCommand);
        void Handle(ConnectServerCommand connectServerCommand);
        void Handle(GetAllUserCommand getAllUserCommand);
        void Handle(GetUserInfoCommand getUserInfoCommand);
        void Send(TryConnectClientCommand tryConnectClientCommand);
        void Send(GetAllUserResponseCommand getAllUserResponseCommand, EndPoint endPoint);
        void Send(GetUserInfoResponseCommand getUserInfoResponseCommand, EndPoint endPoint);
        Socket GetSocket();
    }

}
