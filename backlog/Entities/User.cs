using System;
using System.Collections.Generic;

namespace backlog.Entities
{
    public class User : BaseEntity
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Sub { get; set; }
        public String Picture { get; set; }
        public virtual List<Subscription> Subscriptions { get; set; }
        public virtual List<BoardItem> BoardItems { get; set; }
    }
}
