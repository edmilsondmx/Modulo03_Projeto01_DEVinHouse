using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using DEVinCer.Domain.Services;
using DEVinCer.Domain.Enums;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get(
       [FromQuery] string name,
       [FromQuery] DateTime? birthDateMax,
       [FromQuery] DateTime? birthDateMin
    )
    {
        if(!User.IsInRole(Roles.Admin.GetName()))
            return Ok(ConverterUser.ToDto(_userService.ListAll(name, birthDateMax, birthDateMin)));
        
        return Ok(_userService.ListAll(name, birthDateMax, birthDateMin));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] int id
    )
    {
        if(!User.IsInRole(Roles.Admin.GetName()))
            return Ok(ConverterUser.ToDto(_userService.GetById(id)));

        return Ok(_userService.GetById(id));
    }

    [HttpGet("{userId}/buy")]
    public IActionResult GetByIdbuy(
       [FromRoute] int userId
    )
    {
        return Ok(_userService.GetBuyerByUserID(userId));
    }

    [HttpGet("{userId}/sales")]
    public IActionResult GetSalesBySellerId(
       [FromRoute] int userId
    )
    {
        return Ok(_userService.GetSalesByUserID(userId));
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] UserDTO userDto
    )
    {
        _userService.Insert(userDto);
        return Created("api/users", userDto);
    }

    [HttpPost("{userId}/sales")]
    public IActionResult PostSaleUserId(
        [FromRoute] int userId,
        [FromBody] SaleDTO body
    )
    {
        _userService.InsertSale(userId, body);
        return Created("api/sale", body);
    }

    [HttpPost("{userId}/buy")]
    public IActionResult PostBuyUserId(
        [FromRoute] int userId,
        [FromBody] BuyDTO body
    )
    {
        _userService.InsertBuy(userId, body);
        return Created("api/user/{userId}/buy", body);
    }
      

    [HttpDelete("{userId}")]
    public IActionResult Delete(
       [FromRoute] int userId
    )
    {
        _userService.DeleteUser(userId);
        return NoContent();
    }

    [HttpPut("{userId}")]
    public IActionResult Put(
        [FromRoute] int userId,
        [FromBody] UserDTO dto
    )
    {
        _userService.Update(userId, dto);
        return NoContent();
    }
}





