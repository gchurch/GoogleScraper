using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSearch.Interfaces
{
    public interface IUrlPositionSearchService
    {
        public string GetUrlPositions(string keywords, string url);
    }
}
