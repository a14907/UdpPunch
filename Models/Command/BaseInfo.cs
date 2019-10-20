using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class BaseInfo
    {
        public EndPoint FromPrivate { get; set; }
        public EndPoint FromPublic { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }

}
