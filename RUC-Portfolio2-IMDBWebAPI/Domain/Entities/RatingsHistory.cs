using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class RatingsHistory
    {
        public string Uconst { get; set; } = null!;
        public int Stars { get; set; }
        public string? Ratingsdate { get; set; }
        public string Tconst { get; set; } = null!;
        public string Rconst { get; set; } = null!;

        public virtual TitleBasic TconstNavigation { get; set; } = null!;
        public virtual User UconstNavigation { get; set; } = null!;
    }
}
