namespace backlog.Entities
{
    public class BoardItem : BaseEntity
    {
        public enum ItemStatus
        {
            Backlog = 0,
            ToDo = 1,
            InProgress = 2,
            Done = 3,
            Rejected = 4
        }
        public ItemStatus Status { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual Article Article { get; set; }
        public virtual Follow Follow { get; set; }
    }
}
