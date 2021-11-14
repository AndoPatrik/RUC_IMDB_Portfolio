using Application.Interfaces.v1.Repositories;

namespace Infrastructure.Repositories.v1.AuthService
{
    public class AuthRepository : IAuthRepository
    {
        public async Task<string> Test() 
        {
            return "works";
        }
    }
}
