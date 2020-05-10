using System;
namespace backlog.Models
{
    public class SubscriptionDto : IDto
    {
        public virtual FeedDto Feed { get; set; }
    }
}
