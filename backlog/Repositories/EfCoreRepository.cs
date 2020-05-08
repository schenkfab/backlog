using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        public readonly TContext context;

        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> AsNoTracking(long id)
        {
            var entity = await context.Set<TEntity>().AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(long id)
        {
            var entity = await context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
