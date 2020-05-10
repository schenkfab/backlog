using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;

namespace backlog.Controllers
{
    public class SubscriptionsController : BaseController<SubscriptionDto, SubscriptionForCreationDto, SubscriptionForUpdateDto, Subscription, SubscriptionRepository>
    {
        public SubscriptionsController(SubscriptionRepository subscriptionRepository, IMapper mapper) : base(subscriptionRepository, mapper)
        {
        }
    }
}
