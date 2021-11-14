using System.Threading.Tasks;

namespace Application.Interfaces.v1.Repositories
{
    public interface IAuthRepository
    {
        public Task<string> Test();
    }
}
