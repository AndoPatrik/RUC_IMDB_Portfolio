using AutoMapper;
using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;
using IMDB.Application.Interfaces.v1.Repositories;
using Infrastructure.Context;

namespace IMDB.Infrastructure.Repositories.v1.AuthService
{
    public class BookmarksRepository : IBookmarksRepository
    {
        private readonly imdbContext _imdbContext;
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;
        private readonly IMapper _mapper;

        public BookmarksRepository(imdbContext imdbContext, IJWTAuthenticationManager jWTAuthenticationManager, IMapper mapper)
        {
            _imdbContext = imdbContext;
            _jWTAuthenticationManager = jWTAuthenticationManager;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> AddNameBookmarkToUser(NameBookmarkDTO nameBookmark)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                NamesBookmarking nameBookmarking = new NamesBookmarking
                {
                    Uconst = nameBookmark.Uconst,
                    Nconst = nameBookmark.Nconst,
                    Namesdate = DateTime.Now.ToString(),
                };

                _imdbContext.NamesBookmarkings.Add(nameBookmarking);

                //var nameBookmarkingDTO = _mapper.Map<NameBookmarkDTO>(nameBookmarking);
                var nameBookmarkingDTO = new NameBookmarkDTO { Nconst = nameBookmarking.Nconst, Uconst = nameBookmark.Uconst };


                await _imdbContext.SaveChangesAsync();
                response.Status = "Name bookmark has been added.";
                response.Data = new { nameBookmarkingDTO };
            }
            catch (Exception ex)
            {
                response.Status = ex.Message;
            }
            return response;  
        }

        public Task<ResponseMessage> AddTitleBookmarkToUser(TitleBookmarkDTO titleBookmark)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> DeleteNameBookmarksByUser(NameBookmarkDTO nameBookmark)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> DeleteTitleBookmarksByUser(TitleBookmarkDTO titleBookmark)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> GetNamesBookmarksByUser(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> GetTitleBookmarksByUser(string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
