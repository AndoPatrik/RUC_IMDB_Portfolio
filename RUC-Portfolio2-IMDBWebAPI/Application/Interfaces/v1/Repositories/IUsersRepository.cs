using IMDB.Application.DTOs;
using System.Threading.Tasks;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface IUsersRepository
    {
        public Task<ResponseMessage> RegisterUser(UserDTO newUser);
    }
}
