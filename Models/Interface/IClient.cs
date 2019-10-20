using System.Net;
using System.Net.Sockets;

namespace Models
{
    public interface IClient
    {
        void Send(GetAllUserCommand getAllUserCommand);
        void Send(GetUserInfoCommand getUserInfoCommand);
        void Handle(GetAllUserResponseCommand getAllUserCommand);
        void Handle(GetUserInfoResponseCommand getUserInfoCommand);
        void Handle<T>(MessageCommand<T> messageCommand) where T : IMessage;
        void Handle(TryConnectClientResponseCommand tryConnectClientCommand, EndPoint endpoint);
        void Send(ConnectServerCommand connectServerCommand);

        void Send<T>(MessageCommand<T> messageCommand) where T : IMessage;
        void Send(TryConnectClientCommand tryConnectClientCommand);
        Socket GetSocket();
    }

}
