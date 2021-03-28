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
            _browserDriver = CreateBrowserDriver();
        }

        private ChromeDriver CreateBrowserDriver()
        {
            var options = new ChromeOptions() { };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);
            return browser;
        }


        public List<string> GetUrlsFromGoogleSearch(string keywords)
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
