using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TDtoToRead, TDtoToCreate, TDtoToUpdate, TEntity, TRepository> : ControllerBase
        where TDtoToCreate : class, IDto
        where TDtoToRead : class, IDto
        where TDtoToUpdate : class, IDtoForUpdate
        where TEntity : class, IEntity
        where TRepository : class, IRepository<TEntity>
    {
        public readonly TRepository repository;
        public readonly IMapper mapper;

        public BaseController(TRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            List<TEntity> records = await repository.GetAll();
            return Ok(mapper.Map<List<TEntity>, List<TDtoToRead>>(records));
        }
        [HttpPost]
        public virtual async Task<IActionResult> Post(TDtoToCreate dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, mapper.Map<TDtoToRead>(entity));
        }
    }
}
