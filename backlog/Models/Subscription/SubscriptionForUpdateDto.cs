using System;
namespace backlog.Models
{
    public class SubscriptionForUpdateDto : IDtoForUpdate
    {

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long FeedId { get; set; }
    }
}
