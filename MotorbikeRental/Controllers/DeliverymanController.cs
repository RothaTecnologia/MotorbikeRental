using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin,Deliveryman")]
    public class DeliverymanController : ControllerBase
    {
        private readonly IDeliverymanService _deliverymanService;

        public DeliverymanController(IDeliverymanService deliverymanService)
        {
            _deliverymanService = deliverymanService;
        }

        [HttpPost]
        [Produces("application/json")]
        //[Authorize(Roles = "Admin,Deliveryman")]
        public async Task<IActionResult> Post([FromBody] DeliverymanViewModel deliverymanViewModel)
        {
            var guid = await _deliverymanService.InsertDeliveryman(deliverymanViewModel);

            if (guid.Message != "Success")
            {
                return BadRequest(guid.Message);
            }

            return Ok(guid);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        //[Authorize(Roles = "Admin,Deliveryman")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var deliveryman = await _deliverymanService.GetDeliverymanByGuid(id);

            if (deliveryman.Message != "Success")
            {
                return BadRequest(deliveryman.Message);
            }

            return Ok(deliveryman);
        }
    }
}
