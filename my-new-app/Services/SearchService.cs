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

        private ChromeDriver _browser;

        public SearchService()
        {
            _browser = CreateBrowser();
        }

        private ChromeDriver CreateBrowser()
        {
            var options = new ChromeOptions() { };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);
            return browser;
        }

        public string GetUrls()
        {
            List<string> urls = GetUrlsFromGoogleSearch();
            string response = "";
            foreach (string url in urls)
            {
                response += (url + "\n");
            }
            return response;
        }

        private List<string> GetUrlsFromGoogleSearch()
        {
            string fullUrl = "https://www.google.co.uk/search?num=100&q=land+registry+search";

            _browser.Navigate().GoToUrl(fullUrl);

            var urls = GetAllUrlResults();

            return urls;
        }

        private List<string> GetAllUrlResults()
        {
            var cites = _browser.FindElementsByTagName("cite");
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