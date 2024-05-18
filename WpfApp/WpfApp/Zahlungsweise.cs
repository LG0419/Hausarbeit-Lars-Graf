using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Zahlungsweise
    {
        public Zahlungsweise()
        {
            Versicherungsvorschlaeges = new HashSet<Versicherungsvorschlaege>();
        }

        public int ZId { get; set; }
        public string? Zahlungsweise1 { get; set; }

        public virtual ICollection<Versicherungsvorschlaege> Versicherungsvorschlaeges { get; set; }
    }
}
