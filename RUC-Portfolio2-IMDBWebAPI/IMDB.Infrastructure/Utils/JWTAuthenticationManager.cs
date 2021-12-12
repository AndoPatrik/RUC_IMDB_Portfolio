using Domain.Entities;
using IMDB.Application.Interfaces.v1;
using IMDB.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IMDB.Infrastructure.Utils
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string _JWTKey;

        public JWTAuthenticationManager(string JWTKey)
        {
            _JWTKey = JWTKey;
        }

        public string CreateJWT(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JWTKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("UserID", user.Uconst)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public DecodedJWT DecodeJWT(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            DecodedJWT decodedToken = new DecodedJWT
            {
                UserID = token.Claims.Where(c => c.Type == "UserID").Select(x => x.Value).FirstOrDefault(),
                IssuedAt = token.IssuedAt
            };
            return decodedToken;
        }
    }
}
