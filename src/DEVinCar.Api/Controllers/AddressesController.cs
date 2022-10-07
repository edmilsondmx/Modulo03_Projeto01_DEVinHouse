using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.Interfaces.Service;
using DEVinCer.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }


    /// <summary>
    /// Lista os endereços cadastrados
    /// </summary>
    /// <param name="cityId">Filtra pelo id da cidade</param>
    /// <param name="stateId">Filtra pelo id do estado</param>
    /// <param name="street">Filtra pelo nome da rua</param>
    /// <param name="cep">Filtra pelo cep</param>
    /// <response code="200">Retorna lista ou com filtros</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int? cityId,
        [FromQuery] int? stateId,
        [FromQuery] string street,
        [FromQuery] string cep
    )
    {
        var result = _addressService
            .ListAll(cityId, stateId, street, cep);
        
        return Ok(result);
    }


    /// <summary>
    ///Atualiza rua, numero, cep e complemento do endereço 
    /// </summary>
    /// <param name="addressPatchDTO"></param>
    /// <param name="addressId">Id do endereço à ser alterado</param>
    /// <response code="204">Endereço alterado com sucesso</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Endereço não encontrado</response>
    [HttpPatch("{addressId}")]
    public IActionResult Patch(
        [FromRoute] int addressId,
        [FromBody] AddressPatchDTO addressPatchDTO)
    {
        _addressService.Update(addressPatchDTO, addressId);
        return NoContent();
    }

    /// <summary>
    /// Deleta um Endereço conforme o Id Informado
    /// </summary>
    /// <param name="addressId">O Id do endereço à ser deletado.</param>
    /// <response code="204">Endereço Deletado</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="404">Endereço não encontrado</response>
    /// <response code="401">Não autenticado</response>
    [HttpDelete("{addressId}")]
    public IActionResult DeleteById(
        [FromRoute] int addressId
    )
    {
        _addressService.Delete(addressId);
        return NoContent();
    }
}
