using AutoMapper;
using backlog.Entities;
using backlog.Models;

namespace backlog.Profiles
{
    public class ErrorProfile : Profile
    {
        public ErrorProfile()
        {
            CreateMap<Error, ErrorDto>();
            CreateMap<ErrorForCreationDto, Error>();
            CreateMap<ErrorDto, Error>();
            CreateMap<ErrorForUpdateDto, Error>();
        }
    }
}
