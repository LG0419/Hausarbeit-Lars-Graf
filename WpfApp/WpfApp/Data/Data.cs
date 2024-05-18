using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Data
{
    public class Data
    {
        public DateTime Verschierungsbeginn;
        public int dauer;
        public string Zahlungsweise ="";
        public string Tier;
        public int Anzahl_Tiere;
        public List<Tier> Tiere;

        public string Versicherungsbeschreibung;
        public decimal Versicherungsbeiträge;


        public DateTime Geburstdatum;
        public string Anrede;
        public string Titel;
        public string Vorname;
        public string Nachname;
        public string plz;
        public string ort;
        public string HN;
        public string Straße;

        public string IBAN;
        public string BIC;
        public string Kreditinstitut;
        public Data() { }

    }
}
