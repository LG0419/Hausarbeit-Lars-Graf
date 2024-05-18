using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Benutzter Benutzter;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Seiten.Loggin(this);
        }
        public void changeview(object o)
        {
            Main.Content = o;
        }
    }
}