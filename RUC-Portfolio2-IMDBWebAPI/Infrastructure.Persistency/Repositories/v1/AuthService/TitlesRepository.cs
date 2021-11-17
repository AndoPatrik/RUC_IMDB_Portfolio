using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                object[] objects = {title, rating, principals};
                mylist.AddRange(objects);

                var jsonString = JsonConvert.SerializeObject(mylist, Formatting.Indented, new JsonConverter[] { new Newtonsoft.Json.Converters.StringEnumConverter() });

                response.Status = "200";
                response.Data = $"{jsonString}";
            }
            catch (Exception ex)
            {
                response.Status = ex.ToString();
            }

            return response;
        }

        public async Task<ResponseMessage> GetAllTitles()
        {
            var response = new ResponseMessage();

            try
            {
                List<object> mylist = new List<object>();
                foreach (var line in _imdbContext.TitleBasics.Take(10))
                {
                    mylist.Add(line);
                }
                var jsonString = JsonConvert.SerializeObject(mylist, Formatting.Indented, new JsonConverter[] { new Newtonsoft.Json.Converters.StringEnumConverter() });

                response.Status = "200";
                response.Data = $"{jsonString}";
            }
            catch (Exception ex)
            {
                response.Status = ex.ToString();
            }

            return response;
        }
    }
}
