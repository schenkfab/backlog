using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedInCollectionDto : IDto
    {
        public virtual List<FeedDto> Feeds { get; set; }
    }
}
