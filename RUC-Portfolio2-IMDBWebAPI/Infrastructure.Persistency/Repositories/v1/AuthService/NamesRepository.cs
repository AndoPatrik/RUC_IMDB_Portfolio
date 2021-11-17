using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                List<object> mylist = new List<object>();
                var name = await _imdbContext.NameBasics.FindAsync(nconst);
                var principals = await _imdbContext.TitlePrincipals.Where(x => x.Nconst == nconst).ToListAsync();
                foreach (var movie in principals)
                {
                    var movies = await _imdbContext.TitleBasics.Where(x => x.Tconst == movie.Tconst).ToListAsync();
                    mylist.AddRange(movies);
                }
                
                object[] objects = { name, principals };
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
