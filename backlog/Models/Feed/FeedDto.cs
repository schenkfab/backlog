using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedDto : IDto
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public DateTime LastCrawl { get; set; }
        public virtual List<FeedInCollectionForFeedDto> FeedInCollections { get; set; }
        public int NrOfArticles { get; set; }
        public int NrOfArticlesLast7Days { get; set; }
    }
}
