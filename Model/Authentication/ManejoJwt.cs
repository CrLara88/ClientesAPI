using EdenredTest.Model.Authentication.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace EdenredTest.Model.Authentication
{
    public class ManejoJwt: IManejoJwt
    {
        public IConfiguration configuration;

        public ManejoJwt(IConfiguration _configuration)
        {

            configuration = _configuration;
        }

        public string GenerarToken(string email, string password)
        {
            var keyJwt = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("ConfiguracionJwt:Llave").Get<string>() ?? string.Empty));
            var credentials = new SigningCredentials(keyJwt, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                    new Claim("Email", email),
                    new Claim("Password", password)
                };

            var tokenJwt = new JwtSecurityToken
            (
                issuer: null,
                audience: null,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenJwt);
        }
    }
}
