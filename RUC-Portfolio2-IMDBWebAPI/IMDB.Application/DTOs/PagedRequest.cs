namespace IMDB.Application.DTOs
{
    public class PagedRequest
    {
        public PagedRequest()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PagedRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize > 50 ? 50 : pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
