using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Middleware
{
    public class UserObject : IUserObject
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string Sub { get; set; }
    }
}
