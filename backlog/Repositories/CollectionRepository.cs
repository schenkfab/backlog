using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backlog.Contexts;
using backlog.Entities;

namespace backlog.Repositories
{
    public class CollectionRepository : EfCoreRepository<Collection, DatabaseContext>, ICollectionRepository
    {
        public CollectionRepository(DatabaseContext context) : base(context) { }


        public async Task<int> AddFeedToCollection(long feedId, long collectionId)
        {
            await context.Set<FeedInCollection>().AddAsync(new FeedInCollection() { CollectionId = collectionId, FeedId = feedId });
            await context.SaveChangesAsync();

            return 1;
        }
    }
}
