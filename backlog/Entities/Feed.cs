using System;
using System.Collections.Generic;

namespace backlog.Entities
{
    public class Feed : BaseEntity
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public DateTime LastCrawl { get; set; }
        public virtual List<Article> Articles { get; set; }
        public virtual List<FeedInCollection> FeedInCollections { get; set; }
    }
}
