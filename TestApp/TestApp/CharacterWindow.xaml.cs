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
    /// Interaction logic for CharacterWindow.xaml
    /// </summary>
    public partial class CharacterWindow : Window
    {
        public CharacterWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AantalWindow aantalWindow = new AantalWindow();
            aantalWindow.Show();
            this.Close();
        }

        private void Opslaan_Click(object sender, RoutedEventArgs e)
        {

            // Haal de namen op uit de TextBoxen
            PlayerInfo.spelerNaam1 = SpelerNaamTextBox1.Text;
            PlayerInfo.spelerNaam2 = SpelerNaamTextBox2.Text;

            MessageBox.Show($"Speler 1: {PlayerInfo.spelerNaam1}, Speler 2: {PlayerInfo.spelerNaam2}");
            LevelWindow levelWindow = new LevelWindow();
            levelWindow.Show();
            this.Close();

        }
        
    }
}
