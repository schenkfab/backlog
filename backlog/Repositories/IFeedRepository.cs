using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backlog.Entities;

namespace backlog.Repositories
{
    public interface IFeedRepository : IRepository<Feed>
    {
        Task<List<FeedStatistic>> GetStatistics();
    }
}
