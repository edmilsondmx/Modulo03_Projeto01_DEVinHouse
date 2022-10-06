using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliverController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public IActionResult Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            return Ok(_deliveryService.ListAll(addressId, saleId));
        }
    }
}

