using System;
namespace backlog.Models
{
    public class ArticleDto : IDto
    {
        public String Name { get; set; }
        public String Picture { get; set; }
        public String Description { get; set; }
        public String Author { get; set; }
        public String Link { get; set; }
        public DateTime Date { get; set; }
        public virtual FeedDto Feed { get; set; }
    }
}
