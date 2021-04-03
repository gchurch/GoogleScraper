using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlSearch.Interfaces;

namespace UrlSearch.Services
{
    public class BrowserService : IBrowserService
    {
        private ChromeDriver _browserDriver;

        public BrowserService()
        {
            CreateBrowserDriver();
        }

        private void CreateBrowserDriver()
        {
            var options = new ChromeOptions() { };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            _browserDriver = new ChromeDriver(options);
        }

        ~BrowserService()
        {
            QuitBrowserDriver();
        }

        private void QuitBrowserDriver()
        {
            _browserDriver.Quit();
        }

        public void NavigateToUrl(string url)
        {
            _browserDriver.Navigate().GoToUrl(url);
        }

        public List<string> ScrapeTextInCiteTags()
        {
            var citeTags = _browserDriver.FindElementsByTagName("cite");
            List<string> citeTexts = new List<string>();
            foreach (var citeTag in citeTags)
            {
                citeTexts.Add(citeTag.Text);
            }
            return citeTexts;
        }
    }
}