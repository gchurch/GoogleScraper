
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using UrlSearch;

namespace FunctionalTests
{
    [TestClass]
    public class Tests
    {

        public CustomWebApplicationFactory<Startup> _factory = new CustomWebApplicationFactory<Startup>();

        [DataTestMethod]
        [DataRow("api/UrlPositionSearch?keywords=test&url=www.infotrack.co.uk", "2, 6, 7")]
        [DataRow("api/UrlPositionSearch?keywords=test&url=www.google.com", "3")]
        [DataRow("api/UrlPositionSearch?keywords=test&url=www.instagram.com", "0")]
        [DataRow("api/UrlPositionSearch", "0")]
        [DataRow("api/UrlPositionSearch?keywords=&url=www.instagram.com", "0")]
        [DataRow("api/UrlPositionSearch?keywords=test&url=", "0")]
        [DataRow("api/UrlPositionSearch?keywords=&url=", "0")]
        public async Task TestMethod1(string url, string expectedResult)
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            string responseString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedResult, responseString);
        }
    }
}
