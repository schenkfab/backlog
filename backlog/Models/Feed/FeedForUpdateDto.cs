using System;

namespace backlog.Models
{
    public class FeedForUpdateDto : IDtoForUpdate
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public DateTime LastCrawl { get; set; }
    }
}
