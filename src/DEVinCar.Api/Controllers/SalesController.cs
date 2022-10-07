using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;
    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    /// <summary>
    /// Lista a venda cadastrada por seu id
    /// </summary>
    /// <param name="saleId">Filtra venda pelo id</param>
    /// <response code="200">Retorna Venda filtrada</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registro não encontrado</response>
    [HttpGet("{saleId}")]
    public IActionResult GetItensSale(
        [FromRoute] int saleId
    )
    {
        var sale = _saleService.GetById(saleId);
        return Ok(sale);
    }

    /// <summary>
    ///Insere um item na venda 
    /// </summary>
    /// <param name="saleId"> Id da venda a ser inserido o item</param>
    /// <param name="body"> Preencha o item a serem inseridos</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="403">Não autorizado</response>
    [HttpPost("{saleId}/item")]
    [Authorize(Roles = "Manager, Seller")]
    public IActionResult PostSale(
       [FromBody] SaleCarDTO body,
       [FromRoute] int saleId
    )
    {
        _saleService.InsertSale(body, saleId);
        return Created("api/sales/{saleId}/item", body);
    }

    /// <summary>
    ///Insere um entrega na venda 
    /// </summary>
    /// <param name="saleId"> Id da venda a ser inserida a entrega</param>
    /// <param name="body"> Preencha a entrega a ser inserida</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">venda não encontrada</response>
    [HttpPost("{saleId}/deliver")]
    public IActionResult PostDeliver(
        [FromRoute] int saleId,
        [FromBody] DeliveryDTO body
    )
    {
        _saleService.InsertDelivery(body, saleId);
        return Created("api/sales/{saleId}/deliver", body);
    }


    /// <summary>
    ///Altera quantidade de itens da venda 
    /// </summary>
    /// <param name="saleId">Id da venda a ser alterada</param>
    /// <param name="carId">Id do carro à ser alterado</param>
    /// <param name="amount">Quantidade a ser alterada</param>
    /// <response code="204">Quantidade alterada com sucesso</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">venda ou carro não encontrados</response>
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

    /// <summary>
    ///Altera preço unitário de item da venda 
    /// </summary>
    /// <param name="saleId">Id da venda a ser alterada</param>
    /// <param name="carId">Id do carro à ser alterado</param>
    /// <param name="unitPrice">Preço unitário a ser alterado</param>
    /// <response code="204">Preço unitário alterado com sucesso</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">venda ou carro não encontrados</response>
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

