using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Kunden
    {
        public Kunden()
        {
            Versicherungsantrags = new HashSet<Versicherungsantrag>();
        }

        public int KId { get; set; }
        public string? Title { get; set; }
        public string? Anrede { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public string? Bankdaten { get; set; }
        public string? Adresse { get; set; }
        public DateTime? Geburtsdatum { get; set; }

        public virtual ICollection<Versicherungsantrag> Versicherungsantrags { get; set; }
    }
}
