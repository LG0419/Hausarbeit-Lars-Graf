using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Benutzter
    {
        public Benutzter()
        {
            Versicherungsantrags = new HashSet<Versicherungsantrag>();
            Versicherungsvorschlaeges = new HashSet<Versicherungsvorschlaege>();
        }

        public int BId { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public string? Benutztername { get; set; }
        public string? Rolle { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public DateTime? Erstelungsdatum { get; set; }

        public virtual ICollection<Versicherungsantrag> Versicherungsantrags { get; set; }
        public virtual ICollection<Versicherungsvorschlaege> Versicherungsvorschlaeges { get; set; }
    }
}
