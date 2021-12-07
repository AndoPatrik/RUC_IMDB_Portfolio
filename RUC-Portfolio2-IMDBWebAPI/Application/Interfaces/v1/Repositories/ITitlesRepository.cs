using Domain.Entities;
using IMDB.Application.DTOs;
using System.Threading.Tasks;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface ITitlesRepository
    {
        public Task<ResponseMessage> GetTitleByTconst(string tconst);
        public Task<PagedResponse<TitleBasic>> GetAllTitles(PagedRequest pagedRequest);
    }
}
