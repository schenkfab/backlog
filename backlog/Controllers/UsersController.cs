using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backlog.Controllers
{
    public class UsersController : BaseController<UserDto, UserForCreationDto, UserForUpdateDto, User, UserRepository>
    {
        public UsersController(UserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
        }

        public override async Task<IActionResult> Post(UserForCreationDto dto)
        {
            // Check first, if there is already a user with the sub:
            var entity = await repository.GetUserBySub(dto.Sub, true);
            if (entity == null)
            {
                return await base.Post(dto);
            } else
            {
                return Ok(mapper.Map<UserDto>(entity));
            }
        }

        [HttpPatch("{itemId}/{statusId}")]
        public async Task<IActionResult> ChangeStatus(long itemId, int statusId)
        {
            var entity = await repository.UpdateBoardItemStatus(itemId, statusId);
            return Ok(mapper.Map<BoardItemDto>(entity));
        }
    }
}
