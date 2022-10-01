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
        var users = _userService.ListAll(name, birthDateMax, birthDateMin).ToLookup(u => u.Password = "*******");
        
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] int id
    )
    {
        return Ok(_userService.GetById(id));
    }

    [HttpGet("{userId}/buy")]
    public ActionResult<Sale> GetByIdbuy(
       [FromRoute] int userId
    )
    {
        return Ok(_userService.GetBuyerByUserID(userId));
    }

    [HttpGet("{userId}/sales")]
    public ActionResult<Sale> GetSalesBySellerId(
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
    public ActionResult<Sale> PostSaleUserId(
        [FromRoute] int userId,
        [FromBody] SaleDTO body
    )
    {
        _userService.InsertSale(userId, body);
        return Created("api/sale", body);
    }

    [HttpPost("{userId}/buy")]
    public ActionResult<Sale> PostBuyUserId(
        [FromRoute] int userId,
        [FromBody] BuyDTO body
    )
    {
        _userService.InsertBuy(userId, body);
        return Created("api/user/{userId}/buy", body);
    }
      

    [HttpDelete("{userId}")]
    public ActionResult Delete(
       [FromRoute] int userId
    )
    {
        _userService.DeleteUser(userId);
        return NoContent();
    }


}





