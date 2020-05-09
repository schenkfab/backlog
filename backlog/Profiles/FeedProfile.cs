using AutoMapper;
using backlog.Entities;
using backlog.Models;

namespace backlog.Profiles
{
    public class FeedProfile : Profile
    {
        public FeedProfile()
        {
            CreateMap<Feed, FeedDto>();
            CreateMap<FeedForCreationDto, Feed>();
            CreateMap<FeedDto, Feed>();
            CreateMap<FeedForUpdateDto, Feed>();
        }
    }
}
