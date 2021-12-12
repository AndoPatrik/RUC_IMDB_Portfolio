using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using IMDB.Domain.Utils;
using Infrastructure.Context;

namespace IMDB.Infrastructure.Repositories.v1.AuthService
{
    public class UsersRepository : IUsersRepository
    {
        private readonly imdbContext _imdbContext;

        public UsersRepository(imdbContext imdbContext)
        {
            _imdbContext = imdbContext;
        }

        public async Task<ResponseMessage> RegisterUser(UserDTO newUser)
        {
            var response = new ResponseMessage();

            try
            {
                var newUserID = $"u{_imdbContext.Users.Count() + 1}";

                var userToRegister = new User();
                userToRegister.Uconst = newUserID;
                userToRegister.Username = newUser.Username;
                userToRegister.Password = Hashing.HashToSHA256(newUser.Password);

                _imdbContext.Users.Add(userToRegister);
                await _imdbContext.SaveChangesAsync();

                response.Message = $"User with ID:{newUserID} created.";
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }

            return response;
        }
    }
}
