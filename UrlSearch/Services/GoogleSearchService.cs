using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSearch.Services
{
    public class GoogleSearchService : IGoogleSearchService
    {

        private ChromeDriver _browserDriver;

        public GoogleSearchService()
        {
            CreateBrowserDriver();
        }

        ~GoogleSearchService()
        {
            QuitBrowserDriver();
        }

        private void CreateBrowserDriver()
        {
            var options = new ChromeOptions() { };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            _browserDriver = new ChromeDriver(options);
        }

        private void QuitBrowserDriver()
        {
            _browserDriver.Quit();
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
            _browserDriver.Navigate().GoToUrl(fullUrl);
        }

        private string CreateSearchUrl(string keywords)
        {
            string keywordsWithSpacesReplacedByPluses = keywords.Replace(" ", "+");
            string fullUrl = "https://www.google.co.uk/search?num=100&q=" + keywordsWithSpacesReplacedByPluses;
            return fullUrl;
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
