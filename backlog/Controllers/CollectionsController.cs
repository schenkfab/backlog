using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backlog.Controllers
{
    public class CollectionsController : BaseController<CollectionDto, CollectionForCreationDto, CollectionForUpdateDto, Collection, ICollectionRepository>
    {
        public CollectionsController(ICollectionRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [Authorize]
        [Route("addfeedtocollection")]
        [HttpPost]
        public async Task<IActionResult> AddFeedToCollection(FeedInCollectionForCreationDto dto)
        {
            await repository.AddFeedToCollection(dto.FeedId, dto.CollectionId);
            return NoContent();
        }
    }
}
