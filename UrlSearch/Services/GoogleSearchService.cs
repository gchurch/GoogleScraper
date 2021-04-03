using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlSearch.Interfaces;

namespace UrlSearch.Services
{
    public class GoogleSearchService : IGoogleSearchService
    {

        private IBrowserService _browserService;

        public GoogleSearchService(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        public List<string> GetUrlsFromGoogleSearch(string keywords)
        {
            MakeGoogleSearch(keywords);
            var urls = ScrapeUrlResultsFromPage();
            return urls;
        }

        private void MakeGoogleSearch(string keywords)
        {
            string fullUrl = CreateSearchUrl(keywords);
            Console.WriteLine(fullUrl);
            _browserService.NavigateToUrl(fullUrl);
        }

        private string CreateSearchUrl(string keywords)
        {
            string keywordsWithSpacesReplacedByPluses = keywords.Replace(" ", "+");
            string fullUrl = "https://www.google.co.uk/search?num=100&q=" + keywordsWithSpacesReplacedByPluses;
            return fullUrl;
        }

        private List<string> ScrapeUrlResultsFromPage()
        {
            List<string> cites = _browserService.ScrapeTextInCiteTags();
            var urls = new List<string>();
            foreach (var cite in cites)
            {
                if (cite != "")
                {
                    var firstSpaceIndex = cite.IndexOf(" ");
                    string firstString;
                    if (firstSpaceIndex > 0)
                    {
                        firstString = cite.Substring(0, firstSpaceIndex);
                    }
                    else
                    {
                        firstString = cite;
                    }
                    urls.Add(firstString);
                }
            }
            return urls;
        }
    }
}
