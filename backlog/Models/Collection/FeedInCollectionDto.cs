using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedInCollectionDto : IDto
    {
        public virtual long FeedId { get; set; }
    }
}
