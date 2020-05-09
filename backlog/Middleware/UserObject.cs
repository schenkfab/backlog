using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Middleware
{
    public class UserObject : IUserObject
    {
        public long UserId { get; set; } = -1;
        public string Token { get; set; } = null;
        public string Sub { get; set; } = null;
    }
}
