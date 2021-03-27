using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("int")]
        public ActionResult<int> GetInt()
        {
            return Ok(200);
        }

        [HttpGet("string")]
        public ActionResult<string> GetString()
        {
            return Ok("hello");
        }
    }
}
