using System;
namespace backlog.Entities
{
    public class FeedInCollection : BaseEntity
    {
        public virtual long FeedId { get; set; }
        public virtual Feed Feed { get; set; }
        public virtual long CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
