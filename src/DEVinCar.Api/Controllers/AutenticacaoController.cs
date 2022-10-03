using AutoMapper;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;
using DEVinCer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutenticacaoController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AutenticacaoController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route ("login")]
    [AllowAnonymous]
    public IActionResult Login(
        [FromBody] LoginDTO login
    )
    {
        var user = _userService.GetByUser(login);
        if(user == null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var token = TokenService.GenerateToken(_mapper.Map<User>(user));

        return Ok("bearer " + token);
    }
}
