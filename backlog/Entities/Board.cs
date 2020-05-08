﻿using System;
using System.Collections.Generic;

namespace backlog.Entities
{
    public class Board : BaseEntity
    {
        public String Name { get; set; }
        public virtual User User { get; set; }
        public virtual List<BoardSubscription> BoardSubscriptions { get; set; }
    }
}