using System;

namespace Models
{
    [Serializable]
    public class GetUserInfoCommand : BaseInfo
    {
        public Guid TargetUserId { get; set; }
    }

}
