using AutoMapper;
using backlog.Entities;
using backlog.Models;
using backlog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OPMLHelper;
using System.Collections.Generic;

namespace backlog.Controllers
{
    public class FeedsController : BaseController<FeedDto, FeedForCreationDto, FeedForUpdateDto, Feed, IFeedRepository>
    {
        public FeedsController(IFeedRepository feedRepository, IMapper mapper) : base(feedRepository, mapper)
        {
        }

        [Authorize]
        [Route("importopml")]
        [HttpPost()]
        public async Task<IActionResult> ImportOPML([FromBody] XmlString xml)
        {
            OPML feeds = new OPML(xml.xml);
            return Ok(feeds.outlines);
        }

        public class XmlString
        {
            public string xml { get; set; }
        }

        [Authorize]
        [Route("statistics")]
        [HttpGet]
        public async Task<IEnumerable<FeedStatistic>> GetStatistics()
        {
            return await repository.GetStatistics();
        }

    }
}
