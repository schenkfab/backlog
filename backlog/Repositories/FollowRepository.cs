using System;
using System.Threading.Tasks;
using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace backlog.Repositories
{
    public class FollowRepository : EfCoreRepository<Follow, DatabaseContext>, IFollowRepository
    {
        public FollowRepository(DatabaseContext context) : base(context) { }

        public async Task<int> Unfollow(long id)
        {
            await context.Database.ExecuteSqlRawAsync("dbo.usp_unfollow @Id = {0}", id);
            return 1;
        }

        public async Task<int> SyncBoardItems()
        {
            await context.Database.ExecuteSqlRawAsync("dbo.usp_SyncBoardItems");
            return 1;
        }
    }
}
