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
        public void Get_GivenNullKeywords_ShouldReturnBadRequest()
        {
            // Arrange
            Mock<IUrlSearchService> urlSearchServiceMock = new Mock<IUrlSearchService>();
            UrlSearchController urlSearchController = new UrlSearchController(urlSearchServiceMock.Object);
            string keywords = null;
            string url = "www.infotrack.co.uk";

            // Act
            ActionResult<string> actionResult = urlSearchController.Get(keywords, url);

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.Result.GetType());
        }

        [TestMethod]
        public void Get_GivenNullUrl_ShouldReturnBadRequest()
        {
            // Arrange
            Mock<IUrlSearchService> urlSearchServiceMock = new Mock<IUrlSearchService>();
            UrlSearchController urlSearchController = new UrlSearchController(urlSearchServiceMock.Object);
            string keywords = "test test";
            string url = null;

            // Act
            ActionResult<string> actionResult = urlSearchController.Get(keywords, url);

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.Result.GetType());
        }

        [TestMethod]
        public void Get_GivenNonNullArguments_ShouldReturnOk()
        {
            // Arrange
            Mock<IUrlSearchService> urlSearchServiceMock = new Mock<IUrlSearchService>();
            UrlSearchController urlSearchController = new UrlSearchController(urlSearchServiceMock.Object);
            string keywords = "test test";
            string url = "www.infotrack.co.uk";

            // Act
            ActionResult<string> actionResult = urlSearchController.Get(keywords, url);

            // Assert
            Assert.AreEqual(typeof(OkObjectResult), actionResult.Result.GetType());
        }
    }
}
