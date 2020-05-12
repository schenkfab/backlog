using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class UserRepository : EfCoreRepository<User, DatabaseContext>
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
            BoardItem.ItemStatus status = BoardItem.ItemStatus.Backlog;
            if (statusId == 0)
            {
                status = BoardItem.ItemStatus.Backlog;
            }
            else if (statusId == 1)
            {
                status = BoardItem.ItemStatus.ToDo;
            }
            else if (statusId == 2)
            {
                status = BoardItem.ItemStatus.InProgress;
            }
            else if (statusId == 3)
            {
                status = BoardItem.ItemStatus.Done;
            }
            else if (statusId == 4)
            {
                status = BoardItem.ItemStatus.Rejected;
            }

            var entity = context.BoardItems.FirstOrDefault(o => o.Id == itemId);
            entity.Status = status;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
