using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlSearch.Controllers;
using UrlSearch.Interfaces;

namespace UnitTests.Controllers
{
    [TestClass]
    public class UrlSearchControllerTests
    {
        [TestMethod]
        public void UrlPositionSearch_GivenNullKeywords_ShouldReturnBadRequest()
        {
            // Arrange
            Mock<IUrlPositionSearchService> urlPositionSearchServiceMock = new Mock<IUrlPositionSearchService>();
            UrlPositionSearchController urlPositionSearchController = new UrlPositionSearchController(urlPositionSearchServiceMock.Object);
            string keywords = null;
            string url = "www.infotrack.co.uk";

            // Act
            ActionResult<string> actionResult = urlPositionSearchController.UrlPositionSearch(keywords, url);

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.Result.GetType());
        }

        [TestMethod]
        public void UrlPositionSearch_GivenNullUrl_ShouldReturnBadRequest()
        {
            // Arrange
            Mock<IUrlPositionSearchService> UrlPositionSearchServiceMock = new Mock<IUrlPositionSearchService>();
            UrlPositionSearchController UrlPositionSearchController = new UrlPositionSearchController(UrlPositionSearchServiceMock.Object);
            string keywords = "test test";
            string url = null;

            // Act
            ActionResult<string> actionResult = UrlPositionSearchController.UrlPositionSearch(keywords, url);

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.Result.GetType());
        }

        [TestMethod]
        public void UrlPositionSearch_GivenNonNullArguments_ShouldReturnOk()
        {
            // Arrange
            Mock<IUrlPositionSearchService> UrlPositionSearchServiceMock = new Mock<IUrlPositionSearchService>();
            UrlPositionSearchController UrlPositionSearchController = new UrlPositionSearchController(UrlPositionSearchServiceMock.Object);
            string keywords = "test test";
            string url = "www.infotrack.co.uk";

            // Act
            ActionResult<string> actionResult = UrlPositionSearchController.UrlPositionSearch(keywords, url);

            // Assert
            Assert.AreEqual(typeof(OkObjectResult), actionResult.Result.GetType());
        }
    }
}
