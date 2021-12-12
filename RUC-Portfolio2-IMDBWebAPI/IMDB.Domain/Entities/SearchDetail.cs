using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class SearchDetail
    {
        public string Sconst { get; set; } = null!;
        public string? Title { get; set; }
        public string? PlotText { get; set; }
        public string? Character { get; set; }
        public string? ActorName { get; set; }

        public virtual SearchHistory SconstNavigation { get; set; } = null!;
    }
}
