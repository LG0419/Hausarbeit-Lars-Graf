using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Seiten
{
    /// <summary>
    /// Interaktionslogik für Angaben_zur_Zahlung.xaml
    /// </summary>

    public partial class Angaben_zur_Zahlung : Page
    {
        public MainWindow window;

        Data.Data d;
        public Angaben_zur_Zahlung(MainWindow window, Data.Data d)
        {
            this.window = window;
            this.d = d;

            InitializeComponent();
            Kreditinstitut.Text = d.Kreditinstitut;
            IBAN.Text = d.IBAN;
            BIC.Text = d.BIC;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool t = true;
            try
            {
                d.Kreditinstitut = Kreditinstitut.Text;
                d.IBAN = IBAN.Text;
                d.BIC = BIC.Text;
            }
            catch { t = false; }
            if (d.Kreditinstitut == "" || d.Kreditinstitut == null) { t = false; }
            if (d.IBAN == "" || d.IBAN == null) { t = false; }
            if (d.IBAN == "" || d.IBAN == null) { t = false; }
            if (t)
            {
                tvdbContext ctx = new tvdbContext();
                Versicherungsvorschlaege versicherungsvorschlaege = new Versicherungsvorschlaege {
                    
                    Dauer = d.dauer,
                    ZId = ctx.Zahlungsweises.Where(x => x.Zahlungsweise1 == d.Zahlungsweise).ToList()[0].ZId,
                    BId = window.Benutzter.BId,
                    
                };
                versicherungsvorschlaege.Beginn = d.Verschierungsbeginn;
                ctx.Versicherungsvorschlaeges.Add(versicherungsvorschlaege);
                ctx.SaveChanges();

                Kunden kunden = new Kunden {
                Title=d.Titel,
                Anrede=d.Anrede,
                Vorname=d.Vorname,
                Nachname=d.Nachname,
                Bankdaten=d.Kreditinstitut+" "+d.IBAN+" "+d.BIC,
                Adresse=$"{d.plz} {d.ort} {d.Straße} {d.HN}",
                Geburtsdatum=d.Geburstdatum
                
                
                
                };
                ctx.SaveChanges();

                Versicherungsantrag versicherungsantrag = new Versicherungsantrag {
                    Versicherungsbeiträge = d.Versicherungsbeiträge,
                    Antragsbeschreibung = d.Versicherungsbeschreibung,
                    BId = window.Benutzter.BId,
                    KIdNavigation = kunden,
                    VIdNavigation =versicherungsvorschlaege
                    
            };
                ctx.Versicherungsantrags.Add(versicherungsantrag);
                ctx.SaveChanges();

                foreach (Data.Tier item in d.Tiere) {
                
                WpfApp.Tier tier = new WpfApp.Tier();
                    tier.Name = item.Name;
                    tier.Chipnummer = item.Chipnummer;
                    tier.TrId = item.tr.TrId;
                    tier.VIdNavigation = versicherungsvorschlaege;
                    ctx.Tiers.Add(tier);

                }
                ctx.SaveChanges();
                window.changeview(new Loggin(window));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            d.Kreditinstitut = Kreditinstitut.Text;
            d.IBAN = IBAN.Text;
            d.BIC = BIC.Text;
            window.changeview(new Kundendaten(window, d));
        }
    }
}
