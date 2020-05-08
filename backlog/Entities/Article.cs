using System;

namespace backlog.Entities
{
    public class Article : BaseEntity
    {
        public String Name { get; set; }
        public String Picture { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
    }
}
