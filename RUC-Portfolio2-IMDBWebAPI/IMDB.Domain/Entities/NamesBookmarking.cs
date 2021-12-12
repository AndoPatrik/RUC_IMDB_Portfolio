using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class NamesBookmarking
    {
        public string Nconst { get; set; } = null!;
        public string Uconst { get; set; } = null!;
        public string Namesdate { get; set; } = null!;

        public virtual NameBasic NconstNavigation { get; set; } = null!;
        public virtual User UconstNavigation { get; set; } = null!;
    }
}
