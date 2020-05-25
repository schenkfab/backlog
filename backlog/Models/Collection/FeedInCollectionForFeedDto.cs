using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedInCollectionForFeedDto : IDto
    {
        public virtual List<CollectionForFeedDto> Collections { get; set; }
    }
}
