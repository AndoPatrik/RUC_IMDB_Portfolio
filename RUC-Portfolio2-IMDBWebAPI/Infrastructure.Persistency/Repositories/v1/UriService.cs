using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;

namespace IMDB.Infrastructure.Repositories.v1
{
    public class UriService : IUriService
    {
        public string GetNextPageUri(string path, PagedRequest pagedRequest)
        {
            int currentPageNumber = pagedRequest.PageNumber;
            return path.Replace($"PageNumber={currentPageNumber}", $"PageNumber={currentPageNumber + 1}");
        }

        public string GetPreviousPageUri(string path, PagedRequest pagedRequest)
        {
            int currentPageNumber = pagedRequest.PageNumber;
            if (currentPageNumber <= 1) return null;
            return path.Replace($"PageNumber={currentPageNumber}", $"PageNumber={currentPageNumber - 1}");
        }
    }
}
