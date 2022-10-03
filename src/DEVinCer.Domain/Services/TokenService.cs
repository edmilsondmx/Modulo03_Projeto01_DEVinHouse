using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Enums;
using DEVinCer.Domain.Security;
using Microsoft.IdentityModel.Tokens;

namespace DEVinCer.Domain.Services;

public class TokenService
{
    public static string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.GetName()),
        };
        return GenerateToken(claims);
    }

    public static string GenerateToken(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
