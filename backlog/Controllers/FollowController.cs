using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;

namespace backlog.Controllers
{
    public class FollowsController : BaseController<FollowDto, FollowForCreationDto, FollowForUpdateDto, Follow, IFollowRepository>
    {
        public FollowsController(IFollowRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
