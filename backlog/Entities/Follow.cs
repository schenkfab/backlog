using System;
using System.Collections.Generic;

namespace backlog.Entities
{
    public class Follow : BaseEntity
    {
        public virtual long CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<BoardItem> BoardItems { get; set; }
    }
}
