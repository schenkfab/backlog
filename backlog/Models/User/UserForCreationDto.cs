using System;

namespace backlog.Models
{
    public class UserForCreationDto : IDto
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Sub { get; set; }
    }
}
