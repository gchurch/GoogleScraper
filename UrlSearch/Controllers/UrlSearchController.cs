﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlSearchController : ControllerBase
    {

        private readonly IUrlSearchService _searchService;

        public UrlSearchController(IUrlSearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public ActionResult<string> Get(string keywords, string url)
        {
            string response =  _searchService.GetUrlPositions(keywords, url);
            return Ok(response);
        }
    }
}