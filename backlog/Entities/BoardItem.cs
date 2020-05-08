namespace backlog.Entities
{
    public class BoardItem : BaseEntity
    {
        public enum ItemStatus
        {
            Backlog, ToDo, InProgress, Done, Rejected
        }
        public ItemStatus Status { get; set; }
        public User User { get; set; }
        public Board Board { get; set; }
        public Article Article { get; set; }
    }
}
