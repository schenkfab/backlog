using System.Threading.Tasks;
using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backlog.Controllers
{
    public class SubscriptionsController : BaseController<SubscriptionDto, SubscriptionForCreationDto, SubscriptionForUpdateDto, Subscription, ISubscriptionRepository>
    {
        public SubscriptionsController(ISubscriptionRepository subscriptionRepository, IMapper mapper) : base(subscriptionRepository, mapper)
        {
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(long id)
        {
            await repository.Unsubscribe(id);
            return NoContent();
        }
    }
}
