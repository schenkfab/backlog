using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class CollectionForUpdateDto : IDtoForUpdate
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public String Description { get; set; }
        public Boolean IsPrivate { get; set; }
    }
}
