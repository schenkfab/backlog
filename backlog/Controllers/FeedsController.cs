using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backlog.Controllers
{
    public class FeedsController : BaseController<FeedDto, FeedForCreationDto, FeedForUpdateDto, Feed, IFeedRepository>
    {
        public FeedsController(IFeedRepository feedRepository, IMapper mapper) : base(feedRepository, mapper)
        {
        }
    }
}
