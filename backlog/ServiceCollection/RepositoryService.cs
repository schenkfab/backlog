using backlog.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace backlog.ServiceCollection
{
    public static class RepositoryService
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<FeedRepository>();
            services.AddScoped<SubscriptionRepository>();
        }
    }
}
