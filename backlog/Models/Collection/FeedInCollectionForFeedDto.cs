using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedInCollectionForFeedDto : IDto
    {
        public virtual long CollectionId { get; set; }
    }
}
