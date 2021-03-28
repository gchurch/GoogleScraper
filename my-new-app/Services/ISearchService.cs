using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Services
{
    public interface ISearchService
    {
        public string GetUrlPositions(string keywords, string url);
    }
}
