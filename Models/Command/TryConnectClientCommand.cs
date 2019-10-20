using System;

namespace Models
{
    [Serializable]
    public class TryConnectClientCommand : BaseInfo
    {
        public BaseInfo Target { get; set; }
    }

}
