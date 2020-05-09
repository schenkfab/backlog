using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class FeedForCreationDto : IDto
    {
        public String Name { get; set; }
        public String Url { get; set; }
    }
}
