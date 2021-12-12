using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Director
    {
        public string Tconst { get; set; } = null!;
        public string Nconst { get; set; } = null!;

        public virtual NameBasic NconstNavigation { get; set; } = null!;
        public virtual TitleBasic TconstNavigation { get; set; } = null!;
    }
}
