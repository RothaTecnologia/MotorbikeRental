using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        [Produces("application/json")]
        [Authorize(Roles = "Admin,Deliveryman")]
        public async Task<IActionResult> Post([FromBody] RentalViewModel rentalViewModel)
        {
            var guid = await _rentalService.InsertRental(rentalViewModel);

            return Ok(guid);
        }
    }
}
