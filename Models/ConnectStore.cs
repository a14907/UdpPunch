using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class ConnectStore
    {
        private Dictionary<Guid, BaseInfo> _connects { get; } = new Dictionary<Guid, BaseInfo>();

        public void Update(BaseInfo connect)
        {
            _connects[connect.UserId] = connect;
        }
        public void Update(List<BaseInfo> connects)
        {
            foreach (var connect in connects)
            {
                _connects[connect.UserId] = connect;
            }
        }

        public void Delete(Guid userid)
        {
            if (_connects.ContainsKey(userid))
            {
                _connects.Remove(userid);
            }
        }

        public List<BaseInfo> GetAllUser()
        {
            return _connects.Values.ToList();
        }

        public BaseInfo GetByUserId(Guid userId)
        {
            if (_connects.TryGetValue(userId, out BaseInfo baseInfo))
            {
                return baseInfo;
            }
            else
            {
                return null;
            }
        }

    }

}
