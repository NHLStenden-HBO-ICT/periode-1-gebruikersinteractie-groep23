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

namespace TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show(Convert.ToString(Globals.GlobalGeluid.effectenVolume));
            if (Globals.GlobalGeluid.muziekAan == false)
            {
                BackgroundMusicPlayer.Instance.Play();
                Globals.GlobalGeluid.muziekAan = true;
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            AantalWindow aantalWindow = new AantalWindow();
            aantalWindow.Show();
            this.Close();
        }

        private void btnOptie_Click(object sender, RoutedEventArgs e)
        {
            OptieWindow optieWindow = new OptieWindow();
            optieWindow.Show();
            this.Close();
        }
    }
}