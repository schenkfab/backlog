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

        public async Task<User> UpdatePicture(long userId, string picture)
        {
            var entity = await context.Users.FirstOrDefaultAsync<User>(o => o.Id == userId);
            entity.Picture = picture;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateLastLogin(long userId)
        {
            var entity = await context.Users.FirstOrDefaultAsync<User>(o => o.Id == userId);
            entity.PreviousLastLogin = entity.LastLogin;
            entity.LastLogin = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<BoardItem> UpdateBoardItemStatus(long itemId, int statusId)
        {
            var entity = context.BoardItems.FirstOrDefault(o => o.Id == itemId);
            entity.Status = (BoardItem.ItemStatus)statusId;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Collection> CreateInitialCollection(User user, string sub)
        {
            var entity = new Collection()
            {
                Name = sub, IsPrivate = true, User = user, Description = "Private Collection"
            };

            var exists = await context.Set<Collection>().FirstOrDefaultAsync(o => o.Name == sub);
            if (exists == null)
            {
                context.Set<Collection>().Add(entity);
                await context.SaveChangesAsync();
            }

            return exists ?? entity;
        }
    }
}
