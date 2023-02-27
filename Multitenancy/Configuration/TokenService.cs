using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Multitenancy.Configuration
{
    public interface ITokenService
    {
        string GenerateToken(Guid tenancyId);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Guid tenancyId)
        {
            var claims = new Dictionary<string, string> { { "tenancy_id", tenancyId.ToString() } };
            var token = WriteToken(claims);

            return token;
        }

        private string WriteToken(Dictionary<string, string> claims)
        {
            var tokenSecrets = _configuration.GetSection("Jwt");
            var claimsToken = claims.Select(claim => new Claim(claim.Key, claim.Value));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecrets["Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: tokenSecrets["Issuer"], audience: tokenSecrets["Audience"], claims: claimsToken,
                            expires: new DateTime(2024, 01, 01), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
