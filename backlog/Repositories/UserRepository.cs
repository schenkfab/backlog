using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class UserRepository : EfCoreRepository<User, DatabaseContext>
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public User GetUserBySub(string sub, bool isTracking = false)
        {
            if (isTracking)
            {
                return context.Users.Where(u => u.Sub == sub).FirstOrDefault();
            }
            else
            {
                return context.Users.AsNoTracking().Where(u => u.Sub == sub).FirstOrDefault();
            }
        }

        public bool UserSubExists(string sub, bool isTracking = false)
        {
            if (isTracking)
            {
                return context.Users.Any(u => u.Sub == sub);
            }
            else
            {
                return context.Users.AsNoTracking().Any(u => u.Sub == sub);
            }
        }
    }
}
