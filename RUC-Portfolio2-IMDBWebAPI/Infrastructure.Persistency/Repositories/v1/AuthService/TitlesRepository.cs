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
                var title = await _imdbContext.TitleBasics.FindAsync(tconst);
                var rating = await _imdbContext.TitleRatings.Where(x => x.Tconst == tconst).ToListAsync();
                var principals = await _imdbContext.TitlePrincipals.Where(x => x.Tconst == tconst).ToListAsync();
                List<object> mylist = new List<object>();
                object[] objects = { title, rating, principals };
                mylist.AddRange(objects);

                //var jsonString = JsonConvert.SerializeObject(mylist, Formatting.Indented, new JsonConverter[] { new Newtonsoft.Json.Converters.StringEnumConverter() });

                response.Message = $"Title on ID:{title.Tconst} successfully fetched.";
                response.Data = objects;
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
                //TODO: URI service previous + next page
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
