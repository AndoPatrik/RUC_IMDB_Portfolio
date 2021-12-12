using IMDB.Application.DTOs;
using System.Threading.Tasks;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface IBookmarksRepository
    {
        public Task<ResponseMessage> GetTitleBookmarksByUser(string jwtToken);
        public Task<ResponseMessage> GetNamesBookmarksByUser(string jwtToken);
        public Task<ResponseMessage> AddTitleBookmarkToUser(TitleBookmarkDTO titleBookmark);
        public Task<ResponseMessage> AddNameBookmarkToUser(NameBookmarkDTO nameBookmark);
        public Task<ResponseMessage> DeleteTitleBookmarksByUser(TitleBookmarkDTO titleBookmark);
        public Task<ResponseMessage> DeleteNameBookmarksByUser(NameBookmarkDTO nameBookmark);
    }
}
