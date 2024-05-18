using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Versicherungsvorschlaege
    {
        public Versicherungsvorschlaege()
        {
            Tiers = new HashSet<Tier>();
            Versicherungsantrags = new HashSet<Versicherungsantrag>();
        }

        public int VId { get; set; }
        public int? BId { get; set; }
        public int? ZId { get; set; }
        public int? Dauer { get; set; }
        public DateTime? Beginn { get; set; }

        public virtual Benutzter? BIdNavigation { get; set; }
        public virtual Zahlungsweise? ZIdNavigation { get; set; }
        public virtual ICollection<Tier> Tiers { get; set; }
        public virtual ICollection<Versicherungsantrag> Versicherungsantrags { get; set; }
    }
}
