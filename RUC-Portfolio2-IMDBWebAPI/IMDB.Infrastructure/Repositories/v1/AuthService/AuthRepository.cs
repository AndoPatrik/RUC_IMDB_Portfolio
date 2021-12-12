using Application.Interfaces.v1.Repositories;
using IMDB.Application.DTOs;
using IMDB.Domain.Utils;
using IMDB.Infrastructure.Utils;
using Infrastructure.Context;
using IMDB.Application.Interfaces.v1;

namespace Infrastructure.Repositories.v1.AuthService
{
    public class AuthRepository : IAuthRepository
    {
        private readonly imdbContext _imdbContext;
        private readonly IJWTAuthenticationManager _JWTAuthenticationManager;

        public AuthRepository(imdbContext imdbContext, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _imdbContext = imdbContext;
            _JWTAuthenticationManager = jWTAuthenticationManager;
        }

        public async Task<ResponseMessage> Authenticate(UserDTO userToAuth)
        {
            ResponseMessage response = new ResponseMessage();
            var user =  _imdbContext.Users.Where(u => u.Username == userToAuth.Username && u.Password == Hashing.HashToSHA256(userToAuth.Password)).FirstOrDefault();

            if (user is null) 
            {
                response.Message = "Authentication failed.";
                return response;
            }

            response.Message = $"{userToAuth.Username} successfully authenticated";
            response.Data = new { token = _JWTAuthenticationManager.CreateJWT(user) };
            return response;
        }
    }
}
