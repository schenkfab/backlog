using System;
namespace backlog.Models
{
    public class FollowForUpdateDto : IDtoForUpdate
    {
        public long Id { get; set; }
        public long CollectionId { get; set; }
        public long UserId { get; set; }
    }
}