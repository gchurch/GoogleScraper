using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSearch.Services
{
    public interface IUrlSearchService
    {
        public string GetUrlPositions(string keywords, string url);
    }
}
