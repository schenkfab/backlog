using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FollowForSingleDto : IDto
    {
        public long Id { get; set; }
        public virtual CollectionDto Collection { get; set; }
        public virtual List<BoardItemDto> BoardItems { get; set; }
        public int NewItems { get; set; }
    }
}
