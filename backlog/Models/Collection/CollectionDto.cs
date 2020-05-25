﻿using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class CollectionDto : IDto
    {
        public String Name { get; set; }
        public String Language { get; set; }
        public String Description { get; set; }
        public Boolean IsPrivate { get; set; }
        public List<FeedInCollectionDto> FeedsInCollection { get; set; }
    }
}
