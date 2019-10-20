using System;
using System.Net;

namespace Models
{
    [Serializable]
    public class MessageCommand<T> : BaseInfo where T : IMessage
    {
        public EndPoint Target { get; set; }
        public T Content { get; set; }
    }

}
