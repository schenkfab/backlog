using System;
namespace backlog.Models
{
    public class ErrorDto : IDto
    {
        public long Id { get; set; }
        public String Url { get; set; }
    }
}
