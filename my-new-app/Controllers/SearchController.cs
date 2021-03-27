using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_new_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("int")]
        public ActionResult<int> GetInt()
        {
            return Ok(200);
        }

        [HttpGet("string")]
        public ActionResult<string> GetString(string keywords, string url)
        {
            return Ok(keywords + " " + url);
        }
    }
}
