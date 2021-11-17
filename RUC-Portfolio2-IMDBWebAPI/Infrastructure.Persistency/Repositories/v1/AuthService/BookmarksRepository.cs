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

                //TODO: Change to automapper
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

        public async Task<ResponseMessage> DeleteNameBookmarksByUser(NameBookmarkDTO nameBookmark)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                var nameBookmarkToDelete = _imdbContext.NamesBookmarkings.Where(b=>b.Nconst == nameBookmark.Nconst && b.Uconst == nameBookmark.Uconst).FirstOrDefault();

                if (nameBookmarkToDelete is null) 
                {
                    response.Status = "Name bookmarking has been already deleted or does not exist.";
                    return response;
                }

                _imdbContext.NamesBookmarkings.Remove(nameBookmarkToDelete);
                response.Status = "Name bookmarking is sucessfuilly deleted.";
                response.Data = nameBookmark; 
            }
            catch (Exception ex)
            {
                response.Status=ex.Message;
            }
            return response;
        }

        public Task<ResponseMessage> DeleteTitleBookmarksByUser(TitleBookmarkDTO titleBookmark)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseMessage> GetNamesBookmarksByUser(string jwtToken)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                var decodedToken = _jWTAuthenticationManager.DecodeJWT(jwtToken);
                var namesBookmarkings = _imdbContext.NamesBookmarkings.Where(b => b.Uconst == decodedToken.UserID).ToList();
                //var namesBookmarkingsDTOs = _mapper.Map<NameBookmarkDTO>(namesBookmarkings);

                List<NameBookmarkDTO> namesBookmarkingsDTOs = new List<NameBookmarkDTO>();

                //TODO: Change to automapper
                namesBookmarkings.ForEach(b => namesBookmarkingsDTOs.Add(new NameBookmarkDTO { Uconst = b.Uconst, Nconst = b.Nconst }));

                response.Status = "Sucsessful fetching of names bookmarkings";
                response.Data = namesBookmarkingsDTOs;
            }
            catch (Exception ex)
            {
                response.Status=ex.Message;
            }

            return response;
        }

        public Task<ResponseMessage> GetTitleBookmarksByUser(string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
