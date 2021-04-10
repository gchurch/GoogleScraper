using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using UrlSearch.Interfaces;
using UrlSearch.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class GoogleSearchServiceTests
    {

        private List<string> citeTextExample = new List<string>()
        {
            "https://www.gov.uk > ... > Owning and renting a property",
            "",
            "https://www.gov.uk > Organisations",
            "",
            "https://www.gov.uk > ... > Owning and renting a property",
            "",
            "https://eservices.landregistry.gov.uk > QuickEnquiryInit",
            "",
            "https://eservices.landregistry.gov.uk > eservices > view",
            "",
            "https://search-property-information.service.gov.uk",
            "",
            "https://hmlandregistry.blog.gov.uk > 2021/01/26 > who...",
            "",
            "https://hmlandregistry.blog.gov.uk > 2017/11/07 > wev...",
            "",
            "http://landregistry.data.gov.uk > app > ppd",
            "",
            "https://www.nidirect.gov.uk > articles > searching-the-la...",
            "",
            "https://www.landregistryservices.com",
            ""
        };

        private List<string> expectedUrlsExample = new List<string>()
        {
            "https://www.gov.uk",
            "https://www.gov.uk",
            "https://www.gov.uk",
            "https://eservices.landregistry.gov.uk",
            "https://eservices.landregistry.gov.uk",
            "https://search-property-information.service.gov.uk",
            "https://hmlandregistry.blog.gov.uk",
            "https://hmlandregistry.blog.gov.uk",
            "http://landregistry.data.gov.uk",
            "https://www.nidirect.gov.uk",
            "https://www.landregistryservices.com",
        };


        [TestMethod]
        public void GetUrlsFromGoogleSearchTest()
        {
            // Arrange
            Mock<IBrowserService> browserServiceMock = new Mock<IBrowserService>();
            browserServiceMock.Setup(bs => bs.ScrapeTextInCiteTags())
                .Returns(citeTextExample);
            GoogleSearchService googleSearchService = new GoogleSearchService(browserServiceMock.Object);
            var keywords = "test";

            // Act
            var urlResults = googleSearchService.GetUrlsFromGoogleSearch(keywords);

            // Assert
            CollectionAssert.AreEqual(expectedUrlsExample, urlResults);
        }

        [TestMethod]
        public void GetUrlsFromGoogleSearch_WhenBrowserServiceThrowsAnException_ShouldReturnEmptyList()
        {
            // Arrange
            Mock<IBrowserService> browserServiceMock = new Mock<IBrowserService>();
            string url = "www.whatever.com";
            browserServiceMock.Setup(bs => bs.NavigateToUrl(url))
                .Throws(new System.Exception());
            GoogleSearchService googleSearchService = new GoogleSearchService(browserServiceMock.Object);

            // Act
            var keywords = "test";
            var urlResults = googleSearchService.GetUrlsFromGoogleSearch(keywords);

            // Assert
            var expectedUrls = new List<string>();
            CollectionAssert.AreEqual(expectedUrls, urlResults);
            Assert.AreEqual(0, urlResults.Count);
        }
    }
}