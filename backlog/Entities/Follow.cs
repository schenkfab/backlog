using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace backlog.Entities
{
    public class Follow : BaseEntity
    {
        public virtual long CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<BoardItem> BoardItems { get; set; }
        [NotMapped]
        public int NewItems
        {
            get
            {
                if (BoardItems == null)
                {
                    return 0;
                }
                else
                {
                    return BoardItems.Where(x => x.CreatedDate > User.PreviousLastLogin).Count();
                }
            }
            private set { }
        }
    }
}
