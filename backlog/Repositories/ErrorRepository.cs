using backlog.Contexts;
using backlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public class ErrorRepository : EfCoreRepository<Error, DatabaseContext>, IErrorRepository
    {
        public ErrorRepository(DatabaseContext context) : base(context) { }
    }
}
