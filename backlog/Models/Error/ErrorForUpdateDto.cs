using System;
namespace backlog.Models
{
    public class ErrorForUpdateDto : IDtoForUpdate
    {
        public long Id { get; set; }
        public String Url { get; set; }
    }
}
