using System.Collections.Generic;

namespace IMDB.Application.DTOs
{
    public class PagedResponse<T>
    {
        public PagedResponse(){}

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }
        public string Message { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
