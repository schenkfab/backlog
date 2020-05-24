using System;
using System.Threading.Tasks;
using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backlog.Controllers
{
    public class ErrorsController : BaseController<ErrorDto, ErrorForCreationDto, ErrorForUpdateDto, Error, IErrorRepository>
    {
        public ErrorsController(IErrorRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(long id)
        {
            return Unauthorized();
        }
    }
}
