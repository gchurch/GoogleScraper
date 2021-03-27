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
        public string GetUrls()
        {
            //string url = "https://www.google.co.uk/search?num=100&q=land+registry+search";
            //HttpClient client = new HttpClient();
            //string responseBody = await client.GetStringAsync(url);
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
            List<string> programmerLinks = new List<string>();

            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
            };

            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);
            browser.Navigate().GoToUrl(fullUrl);

            var cites = browser.FindElementsByTagName("cite");
            var urls = new List<string>();
            foreach (var cite in cites)
            {
                if (cite.Text != "")
                {
                    urls.Add(cite.Text);
                }
            }

            foreach (var url in urls)
            {
                Console.WriteLine(url);
            }
            Console.WriteLine("Total number: " + urls.Count);
            return urls;
        }
    }
}