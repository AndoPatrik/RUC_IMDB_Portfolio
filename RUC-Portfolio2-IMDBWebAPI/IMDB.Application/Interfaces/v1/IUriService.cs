using IMDB.Application.DTOs;

namespace IMDB.Application.Interfaces.v1
{
    public interface IUriService
    {
        public string GetNextPageUri(string path, PagedRequest pagedRequest);
        public string GetPreviousPageUri(string path, PagedRequest pagedRequest);
    }
}
