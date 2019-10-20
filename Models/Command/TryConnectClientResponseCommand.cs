using System;

namespace Models
{
    [Serializable]
    public class TryConnectClientResponseCommand
    {
        public BaseInfo From { get; set; }
        public BaseInfo Target { get; set; }
        public bool IsFromServer { get; set; }
        public bool IsFix { get; set; }
    }

}
