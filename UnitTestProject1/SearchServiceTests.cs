using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Search.Services;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class SearchServiceTests
    {
        private List<string> _searchResultUrls = new List<string>()
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
        private string _keywords = "test test test";
        private SearchService _searchService;

        public SearchServiceTests()
        {
            _searchService = CreateSearchServiceForTesting();
        }

        private SearchService CreateSearchServiceForTesting()
        {
            Mock<IGoogleSearchService> googleSearchServiceMock = new Mock<IGoogleSearchService>();
            googleSearchServiceMock.Setup(x => x.GetUrlsFromGoogleSearch(_keywords))
                .Returns(_searchResultUrls);
            SearchService searchService = new SearchService(googleSearchServiceMock.Object);
            return searchService;
        }

        [TestMethod]
        public void GetUrlPositions_GivenUrlPresentMultipleTimesInList_ShouldReturnCommaSeparatedPositions()
        {
            // Arrange
            string url = "www.twitter.com";

            // Act
            string positions = _searchService.GetUrlPositions(_keywords, url);

            // Assert
            Assert.AreEqual("4", positions);
        }


        [TestMethod]
        public void GetUrlPositions_GivenUrlPresentOnceInList_ShouldReturnSinglePositionWithNoComma()
        {
            // Arrange
            string url = "www.infotrack.co.uk";

            // Act
            string positions = _searchService.GetUrlPositions(_keywords, url);

            // Assert
            Assert.AreEqual("2, 6, 7", positions);
        }

        [TestMethod]
        public void GetUrlPositions_GivenUrlNotPresentInList_ShouldReturn0()
        {
            // Arrange
            string url = "www.gov.uk";

            // Act
            string positions = _searchService.GetUrlPositions(_keywords, url);

            // Assert
            Assert.AreEqual("0", positions);
        }

        [TestMethod]
        public void GetUrlPositions_GivenUrlThatIsFirstInTheList_ShouldReturn1Not0()
        {
            // Arrange
            string url = "www.facebook.com";

            // Act
            string positions = _searchService.GetUrlPositions(_keywords, url);

            // Assert
            Assert.AreEqual("1", positions);
        }
    }
}
