using System;

namespace Models
{
    [Serializable]
    public class GetUserInfoResponseCommand
    {
        public BaseInfo UserInfo { get; set; }
    }

}
