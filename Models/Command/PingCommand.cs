using System;
using System.Net;

namespace Models
{
    [Serializable]
    public class PingCommand : BaseInfo
    {
        public EndPoint Target { get; set; }
    }

}
