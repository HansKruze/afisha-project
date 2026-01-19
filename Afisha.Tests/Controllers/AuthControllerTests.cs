using Afisha.Api.Controllers;
using Afisha.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Afisha.Tests.Controllers
{
    public class AuthControllerTests
    {
        [Test]
        public void Login_ValidCredentials_ReturnsOk()
        {
            var controller = new AuthController();

            var request = new LoginRequest
            {
                Phone = "77777777777",
                Code = "777777"
            };

            var result = controller.Login(request);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void Login_InvalidPhone_ReturnsUnauthorized()
        {
            var controller = new AuthController();

            var request = new LoginRequest
            {
                Phone = "1234567890",
                Code = "777777"
            };

            var result = controller.Login(request);

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public void Login_InvalidCode_ReturnsUnauthorized()
        {
            var controller = new AuthController();

            var request = new LoginRequest
            {
                Phone = "77777777777",
                Code = "000000"
            };

            var result = controller.Login(request);

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public void Login_EmptyPhone_ReturnsUnauthorized()
        {
            var controller = new AuthController();

            var request = new LoginRequest
            {
                Phone = "",
                Code = "777777"
            };

            var result = controller.Login(request);

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public void Login_EmptyCode_ReturnsUnauthorized()
        {
            var controller = new AuthController();

            var request = new LoginRequest
            {
                Phone = "77777777777",
                Code = ""
            };

            var result = controller.Login(request);

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public void Login_NullRequest_ReturnsBadRequest()
        {
            var controller = new AuthController();

            LoginRequest request = null;

            var result = controller.Login(request);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}
