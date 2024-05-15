using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorbikeRental.Domain.Interfaces.JWT;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationMBRService _authenticationMBRService;

        public LoginController(IAuthenticationMBRService authenticationMBRService)
        {
            _authenticationMBRService = authenticationMBRService;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> GetLogin([FromBody] LoginViewModel login)
        {
            var token = await _authenticationMBRService.LoginAsync(login);

            return Ok(token);
        }
    }
}
