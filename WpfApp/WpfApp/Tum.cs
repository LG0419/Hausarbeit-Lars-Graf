using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Tum
    {
        public Tum()
        {
            Trs = new HashSet<Tr>();
        }

        public int TaId { get; set; }
        public string? Tierart { get; set; }

        public virtual ICollection<Tr> Trs { get; set; }
        public override string ToString()
        {
            return Tierart;
        }
    }
}
