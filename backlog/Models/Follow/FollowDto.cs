using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FollowDto : IDto
    {
        public virtual CollectionDto Collection { get; set; }
        public virtual List<BoardItemDto> BoardItems { get; set; }
    }
}
