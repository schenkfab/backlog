using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Middleware
{
    public interface IUserObject
    {
        long UserId { get; set; }
        string Token { get; set; }
        string Sub { get; set; }
    }
}
