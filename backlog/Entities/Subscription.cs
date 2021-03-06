﻿using System.Collections.Generic;

namespace backlog.Entities
{
    public class Subscription : BaseEntity
    {
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual long FeedId { get; set; }
        public virtual Feed Feed { get; set; }
    }
}
