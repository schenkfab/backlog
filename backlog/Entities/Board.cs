using System;
using System.Collections.Generic;

namespace backlog.Entities
{
    public class Board : BaseEntity
    {
        public String Name { get; set; }
        public User User { get; set; }
        public virtual List<Subscription> Subscriptions { get; set; }
    }
}
