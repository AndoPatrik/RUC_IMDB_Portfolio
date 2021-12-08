using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IMDB.Infrastructure.Repositories.v1.AuthService
{
    public class NamesRepository : INamesRepository
    {
        private readonly imdbContext _imdbContext;

        public NamesRepository(imdbContext imdbContext)
        {
            _imdbContext = imdbContext;
        }

        public async Task<ResponseMessage> GetNameByNconst(string nconst)
        {
            var response = new ResponseMessage();
            try
            {
                var name = await _imdbContext.NameBasics.Where(n => n.Nconst == nconst).FirstOrDefaultAsync();
                if (name == null)
                {
                    response.Message = $"No name can be found on nconst = {nconst}";
                    return response;
                }
                response.Message = $"Sucessfully fetched name on nconst = {nconst}";
                response.Data = name;
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }
            return response;
        }

        public async Task<PagedResponse<NameBasic>> GetAllNames(PagedRequest pagedRequest)
        {
            var response = new PagedResponse<NameBasic>();
            try
            {
                var skip = (pagedRequest.PageNumber - 1) * pagedRequest.PageSize;
                var names = await _imdbContext.NameBasics.Skip(skip).Take(pagedRequest.PageSize).ToListAsync();
                response.Message = "Sucessful names fetch.";
                response.Data = names;
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }
            return response;
        }
    }
}
