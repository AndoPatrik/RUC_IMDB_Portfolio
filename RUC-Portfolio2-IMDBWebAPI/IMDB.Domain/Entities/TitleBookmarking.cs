using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TitleBookmarking
    {
        public string Tconst { get; set; } = null!;
        public string Uconst { get; set; } = null!;
        public string? Titledate { get; set; }

        public virtual TitleBasic TconstNavigation { get; set; } = null!;
        public virtual User UconstNavigation { get; set; } = null!;
    }
}
