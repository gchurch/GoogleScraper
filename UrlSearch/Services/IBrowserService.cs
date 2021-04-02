using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSearch.Services
{
    public interface IBrowserService
    {
        public void NavigateToUrl(string url);
        public List<string> ScrapeTextInCiteTags();
    }
}