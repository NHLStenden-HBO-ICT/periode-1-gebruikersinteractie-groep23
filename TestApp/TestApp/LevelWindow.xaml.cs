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
    /// Interaction logic for LevelWindow.xaml
    /// </summary>
    public partial class LevelWindow : Window
    {
        public LevelWindow()
        {
            InitializeComponent();
        }

        private void Level1_Click(object sender, RoutedEventArgs e)
        {
            Level1Window level1Window = new Level1Window();
            level1Window.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CharacterWindow characterWindow = new CharacterWindow();
            characterWindow.Show();
            this.Close();
        }
    }
}
