using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class FeedRepository : EfCoreRepository<Feed, DatabaseContext>, IFeedRepository
    {
        public FeedRepository(DatabaseContext context) : base(context) { }
    }
}
