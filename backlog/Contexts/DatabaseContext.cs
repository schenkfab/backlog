using backlog.Entities;
using backlog.Middleware;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace backlog.Contexts
{
    public class DatabaseContext : DbContext
    {
        private readonly IUserObject userObject;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IUserObject userObject) : base(options)
        {
            this.userObject = userObject;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BoardItem>().HasQueryFilter(f => f.UserId == userObject.UserId);
            builder.Entity<Subscription>().HasQueryFilter(f => f.UserId == userObject.UserId);
            builder.Entity<User>().HasQueryFilter(f => f.Id == userObject.UserId);
            builder.Entity<Error>().HasQueryFilter(f => f.UserId == userObject.UserId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => (e.Entity is BaseEntity) && 
                                        (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<BoardItem> BoardItems { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Error> Errors { get; set; }
    }
}
