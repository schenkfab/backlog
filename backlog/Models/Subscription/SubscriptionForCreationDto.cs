using System;
namespace backlog.Models
{
    public class SubscriptionForCreationDto : IDto
    {
        public long FeedId { get; set; }
        public long UserId { get; set; }
    }
}
