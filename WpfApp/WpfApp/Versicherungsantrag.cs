using System;
using System.Collections.Generic;

namespace WpfApp
{
    public partial class Versicherungsantrag
    {
        public int AId { get; set; }
        public int? BId { get; set; }
        public int? VId { get; set; }
        public int? KId { get; set; }
        public decimal? Versicherungsbeiträge { get; set; }
        public string? Antragsbeschreibung { get; set; }

        public virtual Benutzter? BIdNavigation { get; set; }
        public virtual Kunden? KIdNavigation { get; set; }
        public virtual Versicherungsvorschlaege? VIdNavigation { get; set; }
    }
}
