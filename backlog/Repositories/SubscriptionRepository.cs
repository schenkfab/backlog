using backlog.Contexts;
using backlog.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class SubscriptionRepository : EfCoreRepository<Subscription, DatabaseContext>, ISubscriptionRepository
    {
        public SubscriptionRepository(DatabaseContext context) : base(context) { }


        public async Task<int> Unsubscribe(long id)
        {
            await context.Database.ExecuteSqlRawAsync("dbo.usp_unsubscribe @Id = {0}", id);
            return 1;
        }

        public async Task<int> AddSubscribedBoardItems()
        {
            await context.Database.ExecuteSqlRawAsync("dbo.usp_AddSubscribedBoardItems");
            return 1;
        }
    }
}
