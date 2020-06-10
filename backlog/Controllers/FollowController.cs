using System.Threading.Tasks;
using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backlog.Controllers
{
    public class FollowsController : BaseController<FollowDto, FollowForCreationDto, FollowForUpdateDto, Follow, IFollowRepository>
    {
        public FollowsController(IFollowRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Post(FollowForCreationDto dto)
        {
            var x = await base.Post(dto);
            await repository.SyncBoardItems();
            return x;
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(long id)
        {
            // Check if user is owner of the follow:
            var entity = await repository.Get(id);
            if (entity == null)
            {
                return Unauthorized();
            } else
            {
                await repository.Unfollow(id);

                return NoContent();
            }
        }
    }
}
