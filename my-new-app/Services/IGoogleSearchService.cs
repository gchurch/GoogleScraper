using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Services
{
    public interface IGoogleSearchService
    {
        public List<string> GetUrlsFromGoogleSearch(string keywords);
    }
}