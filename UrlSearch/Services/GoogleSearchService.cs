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
            string url = CreateGoogleSearchUrl(keywords);
            _browserService.NavigateToUrl(url);
        }

        private string CreateGoogleSearchUrl(string keywords)
        {
            string keywordsWithSpacesReplacedByPluses = keywords.Replace(" ", "+");
            string url = "https://www.google.co.uk/search?num=100&q=" + keywordsWithSpacesReplacedByPluses;
            return url;
        }

        private List<string> ScrapeUrlResultsFromPage()
        {
            List<string> citeTagTexts = _browserService.ScrapeTextInCiteTags();
            var urls = new List<string>();
            foreach (string citeTagText in citeTagTexts)
            {
                if (citeTagText != "")
                {
                    string url = ExtractUrlFromCiteText(citeTagText);
                    urls.Add(url);
                }
            }
            return urls;
        }

        private string ExtractUrlFromCiteText(string citeTagText)
        {
            var firstSpaceIndex = citeTagText.IndexOf(" ");
            string url;
            if (firstSpaceIndex > 0)
            {
                url = citeTagText.Substring(0, firstSpaceIndex);
            }
            else
            {
                url = citeTagText;
            }
            return url;
        }
    }
}
