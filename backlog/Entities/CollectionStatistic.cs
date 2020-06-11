using System;
namespace backlog.Entities
{
    public class CollectionStatistic
    {
        public long CollectionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NrOfFeeds { get; set; }
        public int NrOfArticles { get; set; }
        public int NrOfArticlesLast7Days { get; set; }
        public int NrOfArticlesLast30Days { get; set; }
        public int NrOfFollowers { get; set; }
        public int NewFollowersLast7Days { get; set; }
        public int NewFollowersLast30Days { get; set; }
    }
}
