using backlog.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace backlog.ServiceCollection
{
    public static class RepositoryService
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeedRepository, FeedRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
        }
    }
}
