using Afisha.Api.Models;
using NUnit.Framework;

namespace Afisha.Tests.Models
{
    public class LoginRequestTests
    {
        [Test]
        public void LoginRequest_ShouldStoreValues()
        {
            var request = new LoginRequest
            {
                Phone = "1234567890",
                Code = "9999"
            };

            Assert.That(request.Phone, Is.EqualTo("1234567890"));
            Assert.That(request.Code, Is.EqualTo("9999"));
        }

        [Test]
        public void LoginRequest_EmptyPhone_ShouldBeInvalid()
        {
            var request = new LoginRequest
            {
                Phone = "",
                Code = "9999"
            };

            Assert.That(string.IsNullOrWhiteSpace(request.Phone), Is.True);
        }

        [Test]
        public void LoginRequest_EmptyCode_ShouldBeInvalid()
        {
            var request = new LoginRequest
            {
                Phone = "1234567890",
                Code = ""
            };

            Assert.That(string.IsNullOrWhiteSpace(request.Code), Is.True);
        }
    }
}
