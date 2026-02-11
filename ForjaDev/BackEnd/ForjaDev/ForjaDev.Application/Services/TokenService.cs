using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ForjaDev.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ForjaDev.Application.Services;

internal class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        var credentials = new SigningCredentials
            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new(claims),
            Expires = DateTime.UtcNow.AddDays(2),
            SigningCredentials = credentials
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public IEnumerable<Claim> GetClaimsByMember(Domain.BackOffice.Entities.Member member)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, member.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };
        return claims;
    }
}