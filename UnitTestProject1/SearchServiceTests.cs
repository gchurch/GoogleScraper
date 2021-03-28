using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using my_new_app.Services;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class SearchServiceTests
    {
        private List<string> searchResultUrls = new List<string>()
        {
            "www.facebook.com",
            "www.infotrack.co.uk",
            "www.google.com",
            "www.twitter.com",
            "www.amazon.com",
            "www.infotrack.co.uk",
            "www.infotrack.co.uk",
            "www.wikipedia.co.uk"
        };
        private string keywords = "test test test";

        private SearchService CreateSearchServiceForTesting()
        {
            Mock<IGoogleSearchService> googleSearchServiceMock = new Mock<IGoogleSearchService>();
            googleSearchServiceMock.Setup(x => x.GetUrlsFromGoogleSearch(keywords))
                .Returns(searchResultUrls);
            SearchService searchService = new SearchService(googleSearchServiceMock.Object);
            return searchService;
        }

        [TestMethod]
        public void GetUrlPositions_GivenUrlPresentMultipleTimesInList_ShouldReturnCommaSeparatedPositions()
        {
            // Arrange
            SearchService searchService = CreateSearchServiceForTesting();

            // Act
            string url = "www.twitter.com";
            string positions = searchService.GetUrlPositions(keywords, url);

            // Assert
            Assert.AreEqual("4", positions);
        }


        [TestMethod]
        public void GetUrlPositions_GivenUrlPresentOnceInList_ShouldReturnSinglePositionWithNoComma()
        {
            // Arrange
            SearchService searchService = CreateSearchServiceForTesting();

            // Act
            string url = "www.infotrack.co.uk";
            string positions = searchService.GetUrlPositions(keywords, url);

            // Assert
            Assert.AreEqual("2, 6, 7", positions);
        }

        [TestMethod]
        public void GetUrlPositions_GivenUrlNotPresentInList_ShouldReturn0()
        {
            // Arrange
            SearchService searchService = CreateSearchServiceForTesting();

            // Act
            string url = "www.gov.uk";
            string positions = searchService.GetUrlPositions(keywords, url);

            // Assert
            Assert.AreEqual("0", positions);
        }

        [TestMethod]
        public void GetUrlPositions_GivenUrlThatIsFirstInTheList_ShouldReturn1Not0()
        {
            // Arrange
            SearchService searchService = CreateSearchServiceForTesting();

            // Act
            string url = "www.facebook.com";
            string positions = searchService.GetUrlPositions(keywords, url);

            // Assert
            Assert.AreEqual("1", positions);
        }
    }
}
