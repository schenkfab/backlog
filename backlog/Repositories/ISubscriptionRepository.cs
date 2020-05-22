using System;
using System.Threading.Tasks;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace backlog.Repositories
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task<int> Unsubscribe(long id);
        Task<int> AddSubscribedBoardItems();
    }

}
