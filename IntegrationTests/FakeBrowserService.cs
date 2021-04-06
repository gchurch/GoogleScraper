using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlSearch.Interfaces;
using UrlSearch.Services;

namespace FunctionalTests
{
    public class FakeBrowserService : IBrowserService
    {
        public void NavigateToUrl(string url)
        {   
        }

        public List<string> ScrapeTextInCiteTags()
        {
            return new List<string>()
            {
                "www.facebook.com",
                "",
                "www.infotrack.co.uk > info",
                "",
                "www.google.com",
                "",
                "www.twitter.com > profile",
                "",
                "www.amazon.com",
                "",
                "www.infotrack.co.uk",
                "",
                "www.infotrack.co.uk",
                "",
                "www.wikipedia.co.uk > search",
                ""
            };
        }
    }
}
