using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backlog.Entities;

namespace backlog.Repositories
{
    public interface ICollectionRepository : IRepository<Collection>
    {
        Task<int> AddFeedToCollection(long feedId, long collectionId);
    }
}
