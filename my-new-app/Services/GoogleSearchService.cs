using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Services
{
    public class GoogleSearchService : IGoogleSearchService
    {

        private ChromeDriver _browserDriver;

        public GoogleSearchService()
        {
            CreateBrowserDriver();
        }

        private void CreateBrowserDriver()
        {
            var options = new ChromeOptions() { };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            _browserDriver = new ChromeDriver(options);
        }

        public List<string> GetUrlsFromGoogleSearch(string keywords)
        {
            MakeGoogleSearch(keywords);
            var urls = ScrapeUrlResultsFromPage();
            return urls;
        }

        private void MakeGoogleSearch(string keywords)
        {
            string fullUrl = "https://www.google.co.uk/search?num=100&q=land+registry+search";
            _browserDriver.Navigate().GoToUrl(fullUrl);
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
