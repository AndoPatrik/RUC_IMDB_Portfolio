using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User
    {
        public User()
        {
            NamesBookmarkings = new HashSet<NamesBookmarking>();
            RatingsHistories = new HashSet<RatingsHistory>();
            SearchHistories = new HashSet<SearchHistory>();
            TitleBookmarkings = new HashSet<TitleBookmarking>();
        }

        public string Uconst { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<NamesBookmarking> NamesBookmarkings { get; set; }
        public virtual ICollection<RatingsHistory> RatingsHistories { get; set; }
        public virtual ICollection<SearchHistory> SearchHistories { get; set; }
        public virtual ICollection<TitleBookmarking> TitleBookmarkings { get; set; }
    }
}
