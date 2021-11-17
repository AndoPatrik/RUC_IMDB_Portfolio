using IMDB.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface INamesRepository
    {
        public Task<ResponseMessage> GetNameByNconst(string nconst);
        public Task<ResponseMessage> GetAllNames();
    }
}
