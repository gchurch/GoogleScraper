using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlSearch.Interfaces;

namespace UrlSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlPositionSearchController : ControllerBase
    {

        private readonly IUrlPositionSearchService _urlPositionSearchService;

        public UrlPositionSearchController(IUrlPositionSearchService urlPositionSearchService)
        {
            _urlPositionSearchService = urlPositionSearchService;
        }

        [HttpGet]
        public ActionResult<string> UrlPositionSearch(string keywords, string url)
        {
            if (keywords != null && url != null)
            {
                string response = _urlPositionSearchService.GetUrlPositions(keywords, url);
                return Ok(response);
            }
            else
            {
                return BadRequest("0");
            }
        }
    }
}
