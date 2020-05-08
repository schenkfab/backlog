using System;

namespace backlog.Entities
{
    public class User : BaseEntity
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Sub { get; set; }
    }
}
