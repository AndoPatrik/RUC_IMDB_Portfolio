using Domain.Entities;
using IMDB.Domain.Models;

namespace IMDB.Application.Interfaces.v1
{
    public interface IJWTAuthenticationManager
    {
        string CreateJWT(User user);
        DecodedJWT DecodeJWT(string jwtToken);
    }
}
