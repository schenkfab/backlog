using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class CollectionDto : IDto
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public String Description { get; set; }
        public Boolean IsPrivate { get; set; }
        public long UserId { get; set; }
        public virtual List<FeedInCollectionDto> FeedInCollections { get; set; }
    }
}
