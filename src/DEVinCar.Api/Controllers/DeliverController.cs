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

        /// <summary>
        /// Lista os veiculos cadastrados
        /// </summary>
        /// <param name="addressId">Filtra pelo id do endereço</param>
        /// <param name="saleId">Filtra pelo id da venda</param>
        /// <response code="200">Retorna lista ou com filtros</response>
        /// <response code="401">Não autenticado</response>
        /// <response code="404">Registros não encontrados</response>
        [HttpGet]
        public IActionResult Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            return Ok(_deliveryService.ListAll(addressId, saleId));
        }
    }
}

