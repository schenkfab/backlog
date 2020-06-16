using System;
namespace backlog.Models
{
    public class ArticleDto : IDto
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
        public String Link { get; set; }
        public DateTime Date { get; set; }
        public virtual FeedForArticleDto Feed { get; set; }
    }
}
