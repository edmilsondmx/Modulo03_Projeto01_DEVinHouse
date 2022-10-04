using AutoMapper;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;
using DEVinCer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        var refreshToken = RefreshTokenService.GenerateRefreshToken();
        RefreshTokenService.SaveRefreshToken(user.Name, refreshToken);

        return Ok(new {
            token, 
            refreshToken
        });
    }
    [HttpPost]
    [Route("refresh-token")]
    [AllowAnonymous]
    public IActionResult Refresh(
        [FromQuery] string token,
        [FromQuery] string refreshToken
    )
    {
        var principal = RefreshTokenService.GetPrincipalFromExpiredToken(token);
        var username = principal.Identity.Name;
        var SaveRefreshToken = RefreshTokenService.GetRefreshToken(username);

        if(SaveRefreshToken != refreshToken)
            throw new SecurityTokenException("Invalid Token");

        var newToken = TokenService.GenerateToken(principal.Claims);
        var newRefreshToken = RefreshTokenService.GenerateRefreshToken();

        RefreshTokenService.DeleteRefreshToken(username, refreshToken);
        RefreshTokenService.SaveRefreshToken(username, newRefreshToken);

        return Ok( new {
            newToken,
            newRefreshToken
        });
    }
}
