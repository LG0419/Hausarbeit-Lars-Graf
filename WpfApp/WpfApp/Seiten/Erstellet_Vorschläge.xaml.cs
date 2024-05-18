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
    /// Interaktionslogik für Erstellet_Vorschläge.xaml
    /// </summary>
    public partial class Erstellet_Vorschläge : Page
    {
        public MainWindow window;

        Data.Data d;
        public Erstellet_Vorschläge(MainWindow window,
        Data.Data d)
        {
            double k =9;
            double mr = 1;
            this.window = window;
            InitializeComponent();
            jl11.Content = "" + (d.Anzahl_Tiere * 1000) + "€";
            jl20.Content = "" + (d.Anzahl_Tiere * 1000) + "€im ersten";
            jl21.Content = "Jahr danach " + (d.Anzahl_Tiere * 20000) + "€";
            jl30.Content = "" + (d.Anzahl_Tiere * 1000) + "€im ersten";
            kl1.Content = d.Zahlungsweise + " Kosten";
            kl2.Content = d.Zahlungsweise + " Kosten";
            kl3.Content = d.Zahlungsweise + " Kosten";

            switch (d.Zahlungsweise)
            {
                case "Monatlich":
                    k = 1;
                    break;
                case "viertel Jährlich":
                    k = 3;
                    break;
                case "halb Jährlich":
                    k = 5;
                    break;
                case "Jährlich":
                    k = 9;
                    break;
            }
            if (d.Anzahl_Tiere > 1) { mr -= 0.05; }
            if (d.Anzahl_Tiere > 3) { mr -= 0.05; }
            if (d.Anzahl_Tiere > 6) { mr -= 0.05; }


            k1.Content = d.Anzahl_Tiere * 7.53 * k *mr;
;
            k2.Content = d.Anzahl_Tiere * 16.9 * k * mr;

;
            k3.Content = d.Anzahl_Tiere * 58.82 * k *mr;
;
            this.d = d;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            window.changeview(new Seiten.Tier(window, 1, d.Tier, d));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            d.Versicherungsbeiträge = Convert.ToDecimal(k2.Content);
            d.Versicherungsbeschreibung = "Stufe 1\n Kostenerstattung im Leistungsfall 80%";
            window.changeview(new Kundendaten(window, d));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            d.Versicherungsbeiträge = Convert.ToDecimal(k2.Content);
            d.Versicherungsbeschreibung = "Stufe 1\n Kostenerstattung im Leistungsfall 100%";
            window.changeview(new Kundendaten(window, d));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            d.Versicherungsbeiträge = Convert.ToDecimal(k1.Content);
            d.Versicherungsbeschreibung = "Stufe 1\n Kostenerstattung im Leistungsfall 100%";
            window.changeview(new Kundendaten(window, d));
        }
    }
}
