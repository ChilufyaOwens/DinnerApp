using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DinnerApp.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider timeProvider, IOptions<JwtSettings> jwtSettingsOption) : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _timeProvider = timeProvider;
    private readonly JwtSettings _jwtSettings = jwtSettingsOption.Value;

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signedCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _timeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes) ,
            claims: claims,
            signingCredentials: signedCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}