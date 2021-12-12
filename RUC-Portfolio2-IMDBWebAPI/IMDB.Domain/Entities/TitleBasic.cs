using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TitleBasic
    {
        public TitleBasic()
        {
            RatingsHistories = new HashSet<RatingsHistory>();
        }

        public string Tconst { get; set; } = null!;
        public string? Titletype { get; set; }
        public string? Primarytitle { get; set; }
        public string? Originaltitle { get; set; }
        public bool? Isadult { get; set; }
        public string? Startyear { get; set; }
        public string? Endyear { get; set; }
        public int? Runtimeminutes { get; set; }

        public virtual OmdbDatum OmdbDatum { get; set; } = null!;
        public virtual TitleBookmarking TitleBookmarking { get; set; } = null!;
        public virtual ICollection<RatingsHistory> RatingsHistories { get; set; }
    }
}
