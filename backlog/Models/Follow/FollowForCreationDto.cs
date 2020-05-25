using System;
namespace backlog.Models
{
    public class FollowForCreationDto : IDto
    {
        public long CollectionId { get; set; }
        public long UserId { get; set; }
    }
}