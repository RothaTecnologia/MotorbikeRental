using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MotorbikeController : ControllerBase
    {
        private readonly IMotorbikeService _motorbikeService;

        public MotorbikeController(IMotorbikeService motorbikeService)
        {
            _motorbikeService = motorbikeService;
        }

        [HttpPost]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] MotorbikeViewModel motorbikeViewModel)
        {
            var guid = await _motorbikeService.InsertMotorbike(motorbikeViewModel);

            return Ok(guid);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var motorBike = await _motorbikeService.GetMotorbikeByGuid(id);

            if (motorBike.Message != "Success")
            {
                return BadRequest(motorBike.Message);
            }

            return Ok(motorBike);
        }

        [HttpGet("LicensePlate/{licensePlate}")]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLicensePlate([FromRoute] string licensePlate)
        {
            var motorBike = await _motorbikeService.GetMotorbikeByLicensePlate(licensePlate);

            if (motorBike.Message != "Success")
            {
                return BadRequest(motorBike.Message);
            }

            return Ok(motorBike);
        }

        [HttpPut("LicensePlate")]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLicensePlate([FromBody] UpdateLicensePlateViewModel upddateLicensePlate)
        {
            var success = await _motorbikeService.UpdateMotorbikeLicensePlateByGuid(upddateLicensePlate.Guid, upddateLicensePlate.LicensePlate);

            if (success.Message != "Success")
            {
                return BadRequest(success.Message);
            }

            return Ok(success);
        }

        [HttpDelete]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] string guid)
        {
            var success = await _motorbikeService.DeleteMotorbikeByGuid(guid);

            if (success.Message != "Success")
            {
                return BadRequest(success.Message);
            }

            return Ok(success);
        }
    }
}
