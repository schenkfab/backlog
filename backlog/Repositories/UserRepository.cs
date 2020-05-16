using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class UserRepository : EfCoreRepository<User, DatabaseContext>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public async Task<User> GetUserBySub(string sub, bool isTracking = false)
        {
            if (isTracking)
            {
                return await context.Users.IgnoreQueryFilters().Where(u => u.Sub == sub).FirstOrDefaultAsync();
            }
            else
            {
                return await context.Users.IgnoreQueryFilters().AsNoTracking().Where(u => u.Sub == sub).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> UserSubExists(string sub, bool isTracking = false)
        {
            if (isTracking)
            {
                return await context.Users.AnyAsync(u => u.Sub == sub);
            }
            else
            {
                return await context.Users.AsNoTracking().AnyAsync(u => u.Sub == sub);
            }
        }

        public async Task<BoardItem> UpdateBoardItemStatus(long itemId, int statusId)
        {
            var entity = context.BoardItems.FirstOrDefault(o => o.Id == itemId);
            entity.Status = (BoardItem.ItemStatus)statusId;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
