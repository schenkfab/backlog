using System;
using backlog.Contexts;
using backlog.Entities;

namespace backlog.Repositories
{
    public class FollowRepository : EfCoreRepository<Follow, DatabaseContext>, IFollowRepository
    {
        public FollowRepository(DatabaseContext context) : base(context) { }
    }
}
