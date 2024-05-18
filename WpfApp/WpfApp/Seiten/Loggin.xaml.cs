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
    /// Interaktionslogik für Loggin.xaml
    /// </summary>
    public partial class Loggin : Page
    {
        public MainWindow window;
        Data.Data d;
        tvdbContext ctx =new tvdbContext();
        public Loggin(MainWindow window)
        {
            this.d = new Data.Data();
            this.window = window;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {List<Benutzter> list = ctx.Benutzters.Where(x => x.Benutztername == b.Text && x.Password == p.Password).ToList();

            if (list.Count() >= 1)
            {
                window.Benutzter = list[0];
                window.changeview(new Seiten.Zur_Versicherung(window, d));
            }
        }
    }
}
