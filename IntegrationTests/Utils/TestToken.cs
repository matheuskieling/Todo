using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationTests.Utils;

public class TestToken
{
    public static string FixedToken => Generate();

    private static string Generate()
    {
        var key = "MYSUPERSECRETKEYTHATSHOULDNOTBEPASSEDTOANYONEINVOLVEDWITHCRACKOROTHERSHITTHATMIGHTBEBADFORYOURHEALTH";
        var issuer = "TodoIssuer";
        var audience = "TodoAudience";
        var userName = "username";
        var userId = "573440b8-55e8-4f69-a7fc-e693718c9b45";
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.NameIdentifier, userId),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}