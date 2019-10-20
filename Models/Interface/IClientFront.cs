using System.Collections.Generic;
using System.Net;

namespace Models
{
    public interface IClientFront
    {
        void ShowMsg(string v);
        void UpdateUserList(List<BaseInfo> userInfos);
        void ClientConnectSuccess(BaseInfo from, EndPoint endpoint);
    }

}
