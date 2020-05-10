using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;

namespace backlog.Controllers
{
    public class SubscriptionController : BaseController<SubscriptionDto, SubscriptionForCreationDto, SubscriptionForUpdateDto, Subscription, SubscriptionRepository>
    {
        public SubscriptionController(SubscriptionRepository subscriptionRepository, IMapper mapper) : base(subscriptionRepository, mapper)
        {
        }
    }
}
