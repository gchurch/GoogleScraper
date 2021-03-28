using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace my_new_app.Services
{
    public class SearchService : ISearchService
    {

        private ChromeDriver _browserDriver;

        public SearchService()
        {
            _browserDriver = CreateBrowserDriver();
        }

        private ChromeDriver CreateBrowserDriver()
        {
            var options = new ChromeOptions() { };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);
            return browser;
        }

        public string GetUrlPositions(string keywords, string url)
        {
            List<string> resultUrls = GetUrlsFromGoogleSearch();
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

        private List<string> GetUrlsFromGoogleSearch()
        {
            string fullUrl = "https://www.google.co.uk/search?num=100&q=land+registry+search";

            _browserDriver.Navigate().GoToUrl(fullUrl);

            var urls = ScrapeUrlResultsFromPage();

            return urls;
        }

        private List<string> ScrapeUrlResultsFromPage()
        {
            var cites = _browserDriver.FindElementsByTagName("cite");
            var urls = new List<string>();
            foreach (var cite in cites)
            {
                if (cite.Text != "")
                {
                    urls.Add(cite.Text);
                }
            }
            return urls;
        }
    }
}