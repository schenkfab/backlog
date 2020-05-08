namespace backlog.Entities
{
    public class BoardItem : BaseEntity
    {
        public enum ItemStatus
        {
            Backlog, ToDo, InProgress, Done, Rejected
        }
        public ItemStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual Board Board { get; set; }
        public virtual Article Article { get; set; }
    }
}
