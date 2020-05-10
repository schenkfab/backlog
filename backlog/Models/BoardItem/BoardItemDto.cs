namespace backlog.Models
{
    public class BoardItemDto : IDto
    {
        public enum ItemStatus
        {
            Backlog, ToDo, InProgress, Done, Rejected
        }
        public ItemStatus Status { get; set; }
        public virtual ArticleDto Article { get; set; }
    }
}
