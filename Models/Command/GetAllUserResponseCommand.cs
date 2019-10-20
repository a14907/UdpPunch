using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class GetAllUserResponseCommand
    {
        public List<BaseInfo> UserInfos { get; set; }
    }

}
