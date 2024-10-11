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
using System.Windows.Shapes;


namespace TestApp
{
    /// <summary>
    /// Interaction logic for OptieWindow.xaml
    /// </summary>
    public partial class OptieWindow : Window
    {
        public OptieWindow()
        {
            InitializeComponent();
            sliderEffecten.Value = Globals.GlobalGeluid.effectenVolume;
            sliderMuziek.Value = Globals.GlobalGeluid.muziekVolume;
        }

        private void sliderEffecten_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Globals.GlobalGeluid.effectenVolume = Convert.ToInt32(sliderEffecten.Value) ;
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(Globals.GlobalGeluid.effectenVolume));
        }

        private void btnTerug_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void sliderMuziek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Globals.GlobalGeluid.muziekVolume = Convert.ToInt32(sliderMuziek.Value);
        }
    }
}
