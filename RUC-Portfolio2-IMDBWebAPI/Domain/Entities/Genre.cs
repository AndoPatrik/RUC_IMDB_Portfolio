using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Genre
    {
        public string Tconst { get; set; } = null!;
        public string Genre1 { get; set; } = null!;

        public virtual TitleBasic TconstNavigation { get; set; } = null!;
    }
}
