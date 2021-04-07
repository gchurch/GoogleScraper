using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UrlSearch.Interfaces;

namespace UrlSearch.Services
{
    public class UrlSearchService : IUrlSearchService
    {

        private readonly IGoogleSearchService _googleSearchService;

        public UrlSearchService(IGoogleSearchService googleSearchService)
        {
            _googleSearchService = googleSearchService;
        }

        public string GetUrlPositions(string keywords, string url)
        {
            List<string> resultUrls = _googleSearchService.GetUrlsFromGoogleSearch(keywords);
            string positions = GetPositionsOfUrlInListOfUrls(url, resultUrls);
            return positions;
        }

        private string GetPositionsOfUrlInListOfUrls(string url, List<string> urls)
        {
            string positions = "";
            for (int i = 0; i < urls.Count; i++)
            {
                if (urls[i].Contains(url))
                {
                    if (positions == "")
                    {
                        positions += (i + 1);
                    }
                    else
                    {
                        positions += (", " + (i + 1));
                    }
                }
            }
            if (positions == "")
            {
                positions = "0";
            }
            return positions;
        }
    }
}