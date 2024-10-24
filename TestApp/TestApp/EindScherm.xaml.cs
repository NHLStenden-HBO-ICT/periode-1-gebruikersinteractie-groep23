using game_7_8;
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
    /// Interaction logic for EindScherm.xaml
    /// </summary>
    public partial class EindScherm : Window
    {
        public EindScherm()
        {
            InitializeComponent();
            spelers.Text = Globals.Namen.Spelernaam1 + " en " + Globals.Namen.Spelernaam2 + " LEVEL GEHAALD";
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LevelsButton_Click(object sender, RoutedEventArgs e)
        {
            LevelWindow levelWindow = new LevelWindow();
            levelWindow.Show();
            this.Close();
        }

        private void OpnieuwButton_Click(object sender, RoutedEventArgs e)
        {
            Level1Window level1Window = new Level1Window();
            level1Window.Show();
            this.Close();
        }
    }
}
