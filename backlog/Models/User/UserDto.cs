using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class UserDto : IDto
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Sub { get; set; }
        public String Picture { get; set; }
    }
}
