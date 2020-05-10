using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class SubscriptionRepository : EfCoreRepository<Subscription, DatabaseContext>
    {
        public SubscriptionRepository(DatabaseContext context) : base(context) { }
    }
}
