using Microsoft.IdentityModel.Tokens;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.JWT;
using MotorbikeRental.Domain.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MotorbikeRental.Services.JWT
{
    public class TokenService: ITokenService
    {

        public string Generate(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtConfiguration.PrivateKey);
            var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserEntity user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ci.AddClaim(new Claim(ClaimTypes.Role, user.UserType.UserTypeDescription));
            
            return ci;
        }
    }
}
