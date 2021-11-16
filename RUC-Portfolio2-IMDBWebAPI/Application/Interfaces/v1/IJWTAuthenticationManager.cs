using Domain.Entities;

namespace IMDB.Application.Interfaces.v1
{
    public interface IJWTAuthenticationManager
    {
        string CreateJWT(User user);
    }
}
