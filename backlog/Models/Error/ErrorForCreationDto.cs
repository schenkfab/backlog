using System;
namespace backlog.Models
{
    public class ErrorForCreationDto : IDto
    {
        public String Url { get; set; }
        public long UserId { get; set; }
    }
}
