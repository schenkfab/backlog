using System;

namespace backlog.Models
{
    public class UserForUpdateDto : IDtoForUpdate
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Picture { get; set; }
        public string Sub { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime PreviousLastLogin { get; set; }
    }
}
