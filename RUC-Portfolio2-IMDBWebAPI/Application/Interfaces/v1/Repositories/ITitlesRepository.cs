using IMDB.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface ITitlesRepository
    {
        public Task<ResponseMessage> GetTitleByTconst(string tconst);
        public Task<ResponseMessage> GetAllTitles();
    }
}
