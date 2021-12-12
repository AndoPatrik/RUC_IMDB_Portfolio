using System;

namespace IMDB.Domain.Models
{
    public class DecodedJWT
    {
        public string UserID { get; set; }
        public DateTime? IssuedAt { get; set; }
    }
}
