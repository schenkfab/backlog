﻿using System;
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
            await repository.SyncBoardItems();
            return NoContent();
        }

        [Authorize]
        [Route("statistics")]
        [HttpGet]
        public async Task<IEnumerable<CollectionStatistic>> GetStatistics()
        {
            return await repository.GetStatistics();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(CollectionForUpdateDto dto)
        {
            var current = await repository.AsNoTracking(dto.Id);
            var entity = mapper.Map<Collection>(dto);

            entity.UserId = current.UserId;
            entity.CreatedDate = current.CreatedDate;

            await repository.Update(entity);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("removefeedfromcollection/{collectionId}/{feedId}")]
        public async Task<IActionResult> RemoveFeedFromCollection(long collectionId, long feedId)
        {
            var ret = await repository.RemoveFeedFromCollection(collectionId, feedId);
            await repository.SyncBoardItems();
            if (ret == -1)
            {
                return Unauthorized();
            } else
            {
                return NoContent();
            }
        }
    }
}
