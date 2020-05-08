using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Entities
{
    public class BoardSubscription : BaseEntity
    {
        public virtual Board Board { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
