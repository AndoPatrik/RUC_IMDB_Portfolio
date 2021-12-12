using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class OmdbDatum
    {
        public string Tconst { get; set; } = null!;
        public string? Poster { get; set; }
        public string? Awards { get; set; }
        public string? Plot { get; set; }

        public virtual TitleBasic TconstNavigation { get; set; } = null!;
    }
}
