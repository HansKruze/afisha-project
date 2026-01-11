using Microsoft.AspNetCore.Mvc;
using Afisha.Api.Models;

namespace Afisha.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // защита от пустого запроса
            if (request == null)
            {
                return BadRequest("Пустой запрос");
            }

            // очистка и подготовка данных
            var phone = new string((request.Phone ?? "").Where(char.IsDigit).ToArray());
            var code = request.Code?.Trim();

            // логируем для отладки (можно убрать позже)
            Console.WriteLine($"PHONE: '{phone}'");
            Console.WriteLine($"CODE: '{code}'");

            // проверка mock-данных
            if (phone == "77777777777" && code == "777777")
            {
                return Ok(new
                {
                    success = true,
                    message = "Успешный вход"
                });
            }

            // если данные неверные
            return Unauthorized(new
            {
                success = false,
                message = "Неверный телефон или код"
            });
        }
    }
}
