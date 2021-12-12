using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TitlePrincipal
    {
        public string? Tconst { get; set; }
        public int? Ordering { get; set; }
        public string? Nconst { get; set; }
        public string? Category { get; set; }
        public string? Job { get; set; }
        public string? Characters { get; set; }

        public virtual TitleBasic? TconstNavigation { get; set; }
    }
}
