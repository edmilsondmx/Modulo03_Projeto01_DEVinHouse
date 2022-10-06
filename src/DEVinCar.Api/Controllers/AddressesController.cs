
using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.Interfaces.Service;
using DEVinCer.Domain.DTOs;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

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

    [HttpPatch("{addressId}")]
    public IActionResult Patch(
        [FromRoute] int addressId,
        [FromBody] AddressPatchDTO addressPatchDTO)
    {
        _addressService.Update(addressPatchDTO, addressId);
        return NoContent();
    }

    [HttpDelete("{addressId}")]
    public IActionResult DeleteById(
        [FromRoute] int addressId
    )
    {
        _addressService.Delete(addressId);
        return NoContent();
    }
}
