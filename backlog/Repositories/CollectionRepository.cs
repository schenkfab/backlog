using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backlog.Contexts;
using backlog.Entities;
using backlog.Middleware;
using Microsoft.EntityFrameworkCore;

namespace backlog.Repositories
{
    public class CollectionRepository : EfCoreRepository<Collection, DatabaseContext>, ICollectionRepository
    {
        private readonly IUserObject UserObject;

        public CollectionRepository(DatabaseContext context, IUserObject userObject) : base(context)
        {
            UserObject = userObject;
        }


        public async Task<int> AddFeedToCollection(long feedId, long collectionId)
        {
            await context.Set<FeedInCollection>().AddAsync(new FeedInCollection() { CollectionId = collectionId, FeedId = feedId });
            await context.SaveChangesAsync();

            return 1;
        }

        public async Task<int> SyncBoardItems()
        {
            await context.Database.ExecuteSqlRawAsync("dbo.usp_SyncBoardItems");
            return 1;
        }

        public async Task<int> RemoveFeedFromCollection(long collectionId, long feedId)
        {
            var entity = context.Set<FeedInCollection>().FirstOrDefault(o => o.CollectionId == collectionId && o.FeedId == feedId);
            if (entity == null)
            {
                return -1;
            } else
            {
                var collection = context.Set<Collection>().FirstOrDefault<Collection>(o => o.Id == entity.CollectionId && o.UserId == UserObject.UserId);

                if (collection == null)
                {
                    return -1;
                }
                else
                {
                    context.Set<FeedInCollection>().Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
            return 1;
        }
    }
}
