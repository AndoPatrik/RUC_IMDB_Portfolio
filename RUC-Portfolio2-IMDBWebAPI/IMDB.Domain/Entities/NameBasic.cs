using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class NameBasic
    {
        public string Nconst { get; set; } = null!;
        public string? Primaryname { get; set; }
        public string? Birthyear { get; set; }
        public string? Deathyear { get; set; }
        public string? Primaryprofession { get; set; }

        public virtual NamesBookmarking NamesBookmarking { get; set; } = null!;
    }
}
