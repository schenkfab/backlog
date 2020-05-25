using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedInCollectionForCreationDto : IDto
    {
        public virtual long FeedId { get; set; }
        public virtual long CollectionId { get; set; }
    }
}
