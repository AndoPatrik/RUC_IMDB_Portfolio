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

        public async Task<ResponseMessage> GetAllNames()
        {
            var response = new ResponseMessage();

            try
            {
                List<object> mylist = new List<object>();
                foreach (var line in _imdbContext.NameBasics.Take(10))
                {
                    mylist.Add(line);
                }
                //var name = await _imdbContext.NameBasics.Find().ToListAsync();
                var jsonString = JsonConvert.SerializeObject(mylist, Formatting.Indented, new JsonConverter[] { new Newtonsoft.Json.Converters.StringEnumConverter() });

                response.Message = "200";
                response.Data = mylist;
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }

            return response;
        }
    }
}
