using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace my_new_app.Services
{
    public class SearchService : ISearchService
    {
        public async Task<string> MakeGoogleRequest()
        {
            string url = "https://www.google.co.uk/search?num=100&q=land+registry+search";
            HttpClient client = new HttpClient();
            string responseBody = await client.GetStringAsync(url);
            return responseBody;
        }
    }
}
