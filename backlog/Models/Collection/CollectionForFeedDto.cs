using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class CollectionForFeedDto : IDto
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public virtual List<FeedInCollectionDto> FeedsInCollection { get; set; }
    }
}
