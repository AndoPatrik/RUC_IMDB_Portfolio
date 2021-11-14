using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class SearchHistory
    {
        public string Sconst { get; set; } = null!;
        public string? Searchdate { get; set; }
        public string SearchText { get; set; } = null!;
        public string Uconst { get; set; } = null!;

        public virtual User UconstNavigation { get; set; } = null!;
        public virtual SearchDetail SearchDetail { get; set; } = null!;
    }
}
