using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliverController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public ActionResult<Delivery> Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            return Ok(_deliveryService.ListAll(addressId, saleId));
        }
    }
}

