using AutoMapper;
using backlog.Entities;
using backlog.Models;

namespace backlog.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserDto, User>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}
