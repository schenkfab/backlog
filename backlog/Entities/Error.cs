using System;
namespace backlog.Entities
{
    public class Error : BaseEntity
    {
        public String Url { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
