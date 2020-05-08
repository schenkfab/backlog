using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;

namespace backlog.Controllers
{
    public class UsersController : BaseController<UserDto, UserForCreationDto, UserForUpdateDto, User, UserRepository>
    {
        public UsersController(UserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
        }
    }
}
