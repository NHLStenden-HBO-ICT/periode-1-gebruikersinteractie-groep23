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
            Globals.Namen.Spelernaam1 = SpelerNaamTextBox1.Text;
            Globals.Namen.Spelernaam2 = SpelerNaamTextBox2.Text;

            CustomizationWindow customizationWindow = new CustomizationWindow();
            customizationWindow.Show();
            this.Close();

        }
        
    }
}
