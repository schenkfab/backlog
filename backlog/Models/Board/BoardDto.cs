using System;
using System.Collections.Generic;

namespace backlog.Models
{
    public class BoardDto : IDto
    {
        public String Name { get; set; }
        public virtual List<BoardItemDto> BoardItems { get; set; }
    }
}
