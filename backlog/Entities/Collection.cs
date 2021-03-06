﻿using System;
using System.Collections.Generic;

namespace backlog.Entities
{
    public class Collection : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Language { get; set; }
        public Boolean IsPrivate { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<FeedInCollection> FeedInCollections { get; set; }
    }
}
