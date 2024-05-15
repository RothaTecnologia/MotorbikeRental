using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] UserViewModel userViewModel)
        {
            var guid = await _userService.InsertUser(userViewModel);

            return Ok(guid);
        }
    }
}
