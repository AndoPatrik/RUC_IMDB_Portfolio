using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Infrastructure.Repositories.v1.AuthService
{
    public class TitlesRepository : ITitlesRepository
    {
        private readonly imdbContext _imdbContext;

        public TitlesRepository(imdbContext imdbContext)
        {
            _imdbContext = imdbContext;
        }

        public async Task<ResponseMessage> GetTitleByTconst(string tconst)
        {
            var response = new ResponseMessage();
            try
            {
                var title = await _imdbContext.TitleBasics.Where(t => t.Tconst == tconst).FirstOrDefaultAsync();
                if (title == null) 
                {
                    response.Message = $"Title on tconst = {tconst} could not be found";
                    return response;
                }
                response.Message = $"Sucessful title fetch on tconst = {tconst}";
                response.Data = title;
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }
            return response;
        }

        public async Task<PagedResponse<TitleBasic>> GetAllTitles(PagedRequest pagedRequest)
        {
            var response = new PagedResponse<TitleBasic>();
            try
            {
                var skip = (pagedRequest.PageNumber - 1) * pagedRequest.PageSize;
                var titles = await _imdbContext.TitleBasics.Skip(skip).Take(pagedRequest.PageSize).ToListAsync();
                response.Message = "Sucessful title fetch.";
                response.Data = titles;
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }
            return response;
        }
    }
}
