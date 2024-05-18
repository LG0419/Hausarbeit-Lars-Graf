using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Tr
    {
        public Tr()
        {
            Tiers = new HashSet<Tier>();
        }

        public int TrId { get; set; }
        public string? Rasse { get; set; }
        public int? Lebenserwartung { get; set; }
        public int? TaId { get; set; }

        public virtual Tum? Ta { get; set; }
        public virtual ICollection<Tier> Tiers { get; set; }
        public override string ToString()
        {
            return Rasse;
        }
    }
}
