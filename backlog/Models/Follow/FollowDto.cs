﻿using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FollowDto : IDto
    {
        public long Id { get; set; }
        public virtual CollectionDto Collection { get; set; }
        public int NewItems { get; set; }
    }
}
