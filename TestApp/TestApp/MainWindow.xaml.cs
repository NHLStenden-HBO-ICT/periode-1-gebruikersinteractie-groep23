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
        public int muziekVoorStil;
        public MainWindow()
        {
            InitializeComponent();
            if (Globals.GlobalGeluid.muziekAan == false)
            {
                BackgroundMusicPlayer.Instance.Play();
                Globals.GlobalGeluid.muziekAan = true;
            }
            if (Globals.GlobalGeluid.muziekVolume == 0)
            {
                BtnMuziekimg.Source = BtnMuziekimg.Source = new BitmapImage(new Uri("Resources/imgMuziekUit.png", UriKind.Relative));
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGeluid_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.GlobalGeluid.muziekVolume != 0)
            {
                muziekVoorStil = Globals.GlobalGeluid.muziekVolume;
                Globals.GlobalGeluid.muziekVolume = 0;
                BtnMuziekimg.Source = BtnMuziekimg.Source = new BitmapImage(new Uri("Resources/imgMuziekUit.png", UriKind.Relative));
                BackgroundMusicPlayer.Instance.SetVolume((Globals.GlobalGeluid.muziekVolume / 100));
            }
            else
            {
                BtnMuziekimg.Source = new BitmapImage(new Uri("Resources/imgMuziekAan.png", UriKind.Relative));
                Globals.GlobalGeluid.muziekVolume = muziekVoorStil;
                BackgroundMusicPlayer.Instance.SetVolume((Globals.GlobalGeluid.muziekVolume / 100));

            }
        }
    }
}