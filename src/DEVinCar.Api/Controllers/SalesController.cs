using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Interfaces.Service;


namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;
    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet("{saleId}")]
    public IActionResult GetItensSale(
        [FromRoute] int saleId
    )
    {
        var sale = _saleService.GetById(saleId);
        return Ok(sale);
    }

    [HttpPost("{saleId}/item")]
    public IActionResult PostSale(
       [FromBody] SaleCarDTO body,
       [FromRoute] int saleId
    )
    {
        _saleService.InsertSale(body, saleId);
        return Created("api/sales/{saleId}/item", body.CarId);
    }

    [HttpPost("{saleId}/deliver")]
    public ActionResult<DeliveryDTO> PostDeliver(
        [FromRoute] int saleId,
        [FromBody] DeliveryDTO body
    )
    {
        _saleService.InsertDelivery(body, saleId);
        return Created("{saleId}/deliver", body);
    }

    [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]
    public IActionResult Patch(
        [FromRoute] int saleId,
        [FromRoute] int carId,
        [FromRoute] int amount
    )
    {
        _saleService.UpdateAmount(saleId, carId, amount);
        return NoContent();
    }

    [HttpPatch("{saleId}/car/{carId}/price/{unitPrice}")]
    public IActionResult Patch(
        [FromRoute] int saleId,
        [FromRoute] int carId,
        [FromRoute] decimal unitPrice
    )
    {
        _saleService.UpdatePrice(saleId, carId, unitPrice);
        return NoContent();
    }

}

