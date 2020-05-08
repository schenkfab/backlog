using System.Collections.Generic;

namespace backlog.Entities
{
    public class Subscription : BaseEntity
    {
        public User User { get; set; }
        public Feed Feed { get; set; }
        public virtual List<Board> Boards { get; set; }
    }
}
