using System;

namespace backlog.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
