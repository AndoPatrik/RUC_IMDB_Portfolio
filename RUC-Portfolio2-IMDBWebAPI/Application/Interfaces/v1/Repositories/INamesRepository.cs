using Domain.Entities;
using IMDB.Application.DTOs;
using System.Threading.Tasks;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface INamesRepository
    {
        public Task<ResponseMessage> GetNameByNconst(string nconst);
        public Task<PagedResponse<NameBasic>> GetAllNames(PagedRequest pagedRequest);
    }
}
