﻿using backlog.Entities;
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
            builder.Entity<Follow>().HasQueryFilter(f => f.UserId == userObject.UserId);
            builder.Entity<Collection>().HasQueryFilter(f => f.UserId == userObject.UserId || f.IsPrivate == false);
            builder.Entity<CollectionStatistic>(e =>
            {
                e.HasNoKey();
                e.ToTable("vCollectionStatistics");
            });
            builder.Entity<FeedStatistic>(e =>
            {
                e.HasNoKey();
                e.ToTable("vFeedStatistics");
            });
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
        public virtual DbSet<CollectionStatistic> CollectionStatistics { get; set; }
        public virtual DbSet<FeedStatistic> FeedStatistics { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<BoardItem> BoardItems { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<FeedInCollection> FeedInCollections { get; set; }
        public DbSet<Follow> Follows { get; set; }
    }
}
