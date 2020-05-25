using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class CollectionForCreationDto : IDto
    {
        public String Name { get; set; }
        public String Language { get; set; }
        public String Description { get; set; }
        public long UserId { get; set; }
        public Boolean IsPrivate { get; set; }
    }
}
