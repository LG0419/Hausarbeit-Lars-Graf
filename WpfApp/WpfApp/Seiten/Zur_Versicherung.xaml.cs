using Microsoft.EntityFrameworkCore;
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
using WpfApp.Data;

namespace WpfApp.Seiten
{
    /// <summary>
    /// Interaktionslogik für Zur_Versicherung.xaml
    /// </summary>
    public partial class Zur_Versicherung : Page
    {
        public MainWindow window;
        Data.Data d;
        int anzhal;
        tvdbContext _context = new tvdbContext();
        public Zur_Versicherung(MainWindow window, Data.Data d)
        {
            this.window = window;
            InitializeComponent();
            if (d.Verschierungsbeginn.CompareTo(DateTime.Today)<0) { d.Verschierungsbeginn = DateTime.Today; }
                DataContext = _context.Ta.ToList();
            this.d = d;
                Tierart.Text = d.Tier;
            ZW.Text = d.Zahlungsweise;
            D.Text = d.dauer.ToString();
            VB.Text = d.Verschierungsbeginn.ToString();
            AT.Text = d.Anzahl_Tiere.ToString();
            anzhal = d.Anzahl_Tiere;


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool t = true;
            try
            {
                d.Tier = Tierart.Text;
                d.dauer = Convert.ToInt32(D.Text);
                d.Verschierungsbeginn = Convert.ToDateTime(VB.Text);
                d.Anzahl_Tiere = Convert.ToInt32(AT.Text);
                d.Zahlungsweise = ZW.Text;
            }
            catch { t = false; }

            if (t)
            {
                if (d.Anzahl_Tiere <= 0) { }
                else if (d.dauer <= 0) { }
                else if (_context.Ta.Where(a => a.Tierart == d.Tier).ToList().Count() <= 0) { }
                else if (d.Verschierungsbeginn.CompareTo(DateTime.Today) < 0) {  }
                else if (d.Zahlungsweise ==null) { }
                else
                {
                    if (anzhal != d.Anzahl_Tiere)
                    {
                        d.Tiere = new List<Data.Tier>();

                        for (int i = 0; i < d.Anzahl_Tiere; i++)
                        {
                            d.Tiere.Add(new Data.Tier());
                        }
                    }
                    window.changeview(new Seiten.Tier(window, d.Anzahl_Tiere, d.Tier, d));
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                d.dauer = Convert.ToInt32(D.Text);
            }
            catch { }
            try
            {
                d.Verschierungsbeginn = Convert.ToDateTime(VB.Text);
            }
            catch { }
            try
            {
                d.Anzahl_Tiere = Convert.ToInt32(AT.Text);
            }
            catch { }
            d.Zahlungsweise = ZW.Text;
            d.Tier = Tierart.Text;

            window.changeview(new Loggin(window));
        }
    }
}
