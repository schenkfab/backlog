using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace backlog.Entities
{
    public class Feed : BaseEntity
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public DateTime LastCrawl { get; set; }
        public virtual List<Article> Articles { get; set; }
        public virtual List<FeedInCollection> FeedInCollections { get; set; }
        [NotMapped]
        public int NrOfArticles {
            get
            {
                if (Articles == null)
                {
                    return 0;
                }
                else
                {
                    return Articles.Count;
                }
            }
            private set {}
        }
        [NotMapped]
        public int NrOfArticlesLast7Days {
            get
            {
                if (Articles == null)
                {
                    return 0;
                }
                else
                {
                    return Articles.Where(o => o.Date > DateTime.Now.AddDays(-7)).Count();
                }
            }
            private set { }
        }
    }
}
