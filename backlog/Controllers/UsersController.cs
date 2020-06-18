using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace backlog.Controllers
{
    public class UsersController : BaseController<UserDto, UserForCreationDto, UserForUpdateDto, User, IUserRepository>
    {
        public UsersController(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
        }

        public override async Task<IActionResult> Post(UserForCreationDto dto)
        {
            // Check first, if there is already a user with the sub:
            var entity = await repository.GetUserBySub(dto.Sub, true);
            if (entity == null)
            {
                var entityToCreate = mapper.Map<User>(dto);
                entityToCreate.LastLogin = DateTime.UtcNow;
                entityToCreate.PreviousLastLogin = DateTime.UtcNow;
                var createdEntity = await repository.Add(entityToCreate);

                await repository.CreateInitialCollection(createdEntity, dto.Sub);

                return await base.Post(dto);
            } else
            {
                if (entity.Picture != dto.Picture)
                {
                    await repository.UpdatePicture(entity.Id, dto.Picture);
                    var updatedEntity = await repository.UpdateLastLogin(entity.Id);
                    await repository.CreateInitialCollection(updatedEntity, dto.Sub);
                    return Ok(mapper.Map<UserDto>(updatedEntity));
                } else
                {
                    await repository.CreateInitialCollection(entity, dto.Sub);
                    var updatedEntity = await repository.UpdateLastLogin(entity.Id);
                    return Ok(mapper.Map<UserDto>(updatedEntity));
                }
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
