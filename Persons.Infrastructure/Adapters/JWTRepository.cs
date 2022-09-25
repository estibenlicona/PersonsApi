using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Persons.Domain.Entities;
using Persons.Domain.Ports;
using Persons.Infrastructure.Configs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persons.Infrastructure.Adapters
{
    public class JWTRepository : IJWTRepository
    {
        private readonly JwtConfig _jwtConfig;
        public JWTRepository(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }
        public string Authenticate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtConfig.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(3).Hour.ToString())
                }),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer,
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string accessToken = tokenHandler.WriteToken(token);
            return accessToken;
        }

        public IEnumerable<Claim> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenData = handler.ReadJwtToken(accessToken);
            return tokenData.Claims;
        }
    }
}
