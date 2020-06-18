using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace backlog.Entities
{
    public class FeedStatistic
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public DateTime LastCrawl { get; set; }
        public int NrOfArticles { get; set; }
        public int NrOfArticlesLast7Days { get; set; }
    }
}
