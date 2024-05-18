using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Tier
    {
        public int TId { get; set; }
        public int? Chipnummer { get; set; }
        public string? Name { get; set; }
        public int? TrId { get; set; }
        public int? VId { get; set; }

        public virtual Tr? Tr { get; set; }
        public virtual Versicherungsvorschlaege? VIdNavigation { get; set; }
    }
}
