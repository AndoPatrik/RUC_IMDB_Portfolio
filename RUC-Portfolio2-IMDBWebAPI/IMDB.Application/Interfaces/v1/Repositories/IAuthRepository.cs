using System.Threading.Tasks;
using IMDB.Application.DTOs;

namespace Application.Interfaces.v1.Repositories
{
    public interface IAuthRepository
    {
        public Task<ResponseMessage> Authenticate(UserDTO userToAuth);
    }
}
