using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSearch.Interfaces
{
    public interface IBrowserService
    {
        public void NavigateToUrl(string url);
        public List<string> ScrapeTextInCiteTags();
    }
}