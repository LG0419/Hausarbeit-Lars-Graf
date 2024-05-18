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
    /// Interaktionslogik für Kundendaten.xaml
    /// </summary>
    public partial class Kundendaten : Page
    {
        public MainWindow window;
        Data.Data d;
        public Kundendaten(MainWindow window, Data.Data d)
        {

            this.window = window;
            InitializeComponent();
            if (d.Geburstdatum.CompareTo(Convert.ToDateTime("1.1.1753 ")) < 0|| d.Geburstdatum.CompareTo(DateTime.Today) > 0) { d.Geburstdatum = DateTime.Today; }
            this.d = d;
            Anrede.Text = d.Anrede;
            Titel.Text = d.Titel;
            Vorname.Text = d.Vorname;
            Nachname.Text = d.Nachname;
            Plz.Text = d.plz;
            Wohnort.Text = d.ort;
            Straße.Text = d.Straße;
            Hausnummer.Text = d.HN;
            gb.Text = d.Geburstdatum.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool t = true;
            try
            {

                d.Anrede = Anrede.Text;
                d.Titel = Titel.Text;
                d.Vorname = Vorname.Text;
                d.Nachname = Nachname.Text;
                d.plz = Plz.Text;
                d.ort = Wohnort.Text;
                d.Straße = Straße.Text;
                d.HN = Hausnummer.Text;
                d.Geburstdatum = Convert.ToDateTime(gb.Text);
            }
            catch { t = false; }
            if (d.Geburstdatum.CompareTo(Convert.ToDateTime("1.1.1753 ")) < 0 || d.Geburstdatum.CompareTo(DateTime.Today) > 0) { t = false; }
            if (d.Vorname == "" || d.Vorname == null) { t = false; }
            if (d.Nachname == "" || d.Nachname == null) { t = false; }
            if (d.plz == "" || d.plz == null) { t = false; }
            if (d.ort == "" || d.ort == null) { t = false; }
            if (d.Straße == "" || d.Straße == null) { t = false; }
            if (d.HN == "" || d.HN == null) { t = false; }
            if (t)
            {
                window.changeview(new Seiten.Angaben_zur_Zahlung(window, d));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {


                d.Geburstdatum = Convert.ToDateTime(gb.Text);
            }
            catch { }
            d.Anrede = Anrede.Text;
            d.Titel = Titel.Text;
            d.Vorname = Vorname.Text;
            d.Nachname = Nachname.Text;
            d.plz = Plz.Text;
            d.ort = Wohnort.Text;
            d.Straße = Straße.Text;
            d.HN = Hausnummer.Text;
            window.changeview(new Seiten.Erstellet_Vorschläge(window, d));
        }
    }
}
