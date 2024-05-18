using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
    /// Interaktionslogik für Tier.xaml
    /// </summary>
    public partial class Tier : Page
    {
        public int anzahl;
        public string tier;
        public MainWindow window;
        tvdbContext _context = new tvdbContext();
        Data.Data d;
        List<Tum> l;
        public Tier(MainWindow window, int anzahl, string tier,
        Data.Data d)
        {
            anzahl--;
            this.window = window;
            this.anzahl = anzahl;
            this.tier = tier;
            this.d = d;

            InitializeComponent();
            l= _context.Ta.Where(a => a.Tierart == tier).Include(x => x.Trs).ToList();
            DataContext = _context.Ta.Where(a => a.Tierart == tier).Include(x => x.Trs).ToList();
            a.Content = $"Angabe zum {tier}:";
            a1.Content = $"Name des {tier}:";
            TN.Text = d.Tiere[anzahl].Name;
            Rasse.Text = d.Tiere[anzahl].Rasse;
            CN.Text = d.Tiere[anzahl].Chipnummer.ToString();
            Alter.Text = d.Tiere[anzahl].Alter.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool t = true;
            try
            {
                d.Tiere[anzahl].Name = TN.Text;
                d.Tiere[anzahl].Rasse = Rasse.Text;
                d.Tiere[anzahl].Chipnummer = Convert.ToInt32(CN.Text);
                d.Tiere[anzahl].Alter = Convert.ToInt32(Alter.Text);
            }
            catch { t = false; }
            if (t)
            {
                List<Tr> l1 = _context.Trs.Where(a => a.Rasse == d.Tiere[anzahl].Rasse).ToList();
                if (l1.Count == 0) { }
                else if (!l[0].Trs.Contains(l1[0])) ;
                else
                {
                    if (anzahl > 0)
                    {
                        d.Tiere[anzahl].tr = l1[0];
                        window.changeview(new Tier(window, anzahl, tier, d));
                    }
                    else
                    {
                        d.Tiere[anzahl].tr = l1[0];
                        window.changeview(new Erstellet_Vorschläge(window, d));
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                d.Tiere[anzahl].Alter = Convert.ToInt32(Alter.Text);
            }
            catch { }

            try
            {
                d.Tiere[anzahl].Chipnummer = Convert.ToInt32(CN.Text);
            }
            catch { }
            d.Tiere[anzahl].Name = TN.Text;
            d.Tiere[anzahl].Rasse = Rasse.Text;
            anzahl += 2;
            if (anzahl > d.Anzahl_Tiere)
            {

                window.changeview(new Zur_Versicherung(window, d));
            }
            else
            {

                window.changeview(new Tier(window, anzahl, tier, d));
            }
        }
    }
}
