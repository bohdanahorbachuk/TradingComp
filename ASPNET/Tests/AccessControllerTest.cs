using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPNET.Controllers;
using ASPNET.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.ContentModel;

namespace ASPNET.Tests.Controllers
{
    [TestClass]
    public class AccessControllerTest
    {
        [TestMethod]
        public void Login_ReturnsViewWhenNotAuthenticated()
        {
            // Arrange
            var controller = new AccessController();

            // Act
            var result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login_RedirectsToHomeControllerIndexWhenAuthenticated()
        {
            // Arrange
            var controller = new AccessController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal(new ClaimsIdentity()) }
            };

            // Act
            var result = controller.Login() as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public async Task Login_ReturnsViewWithValidateMessageWhenInvalidCredentials()
        {
            // Arrange
            var controller = new AccessController();
            var model = new VMLogin { Email = "invalid@example.com", Password = "invalid" };

            // Act
            var result = await controller.Login(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("user not found", result.ViewData["ValidateMessage"]);
        }

        [TestMethod]
        public async Task Login_RedirectsToHomeControllerIndexWhenValidCredentials()
        {
            // Arrange
            var controller = new AccessController();
            var model = new VMLogin { Email = "user@example.com", Password = "123" };

            // Act
            var result = await controller.Login(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }
    }
}
