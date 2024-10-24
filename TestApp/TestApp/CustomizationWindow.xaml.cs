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
    /// Interaction logic for CustomizationWindow.xaml
    /// </summary>
    public partial class CustomizationWindow : Window
    {
        int hoedSpeler1 = 0;
        int hoedSpeler2 = 0;
        private bool isWindowLoaded = false;
        public CustomizationWindow()
        {
            InitializeComponent();
            txtNaam1.Text = Globals.Namen.Spelernaam1;
            txtNaam2.Text = Globals.Namen.Spelernaam2;
            this.Loaded += CustomizationWindow_Loaded;
        }

        // Kijkt of de window compleet is geladen i.v.m. de imgRobots1 en 2 die anders null aangeven
        private void CustomizationWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            isWindowLoaded = true;
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            CharacterWindow characterWindow = new CharacterWindow();
            characterWindow.Show();
            this.Close();
        }

        private void btnNaam1Verder_Click(object sender, RoutedEventArgs e)
        {
            if (hoedSpeler1 != 4)
            {
                hoedSpeler1 += 1;
            }
            else
            {
                hoedSpeler1 = 0;
            }
            imgHoedS1.Source = maskerVeranderen(hoedSpeler1);
        }
        private void btnNaam1Terug_Click(object sender, RoutedEventArgs e)
        {
            if (hoedSpeler1 != 0)
            {
                hoedSpeler1 -= 1;
            }
            else
            {
                hoedSpeler1 = 4;
            }
            imgHoedS1.Source = maskerVeranderen(hoedSpeler1);
        }

        private void btnNaam2Verder_Click(object sender, RoutedEventArgs e)
        {
            if (hoedSpeler2 != 4)
            {
                hoedSpeler2 += 1;
            }
            else
            {
                hoedSpeler2= 0;
            }
            imgHoedS2.Source = maskerVeranderen(hoedSpeler2);
        }

        private void btnNaam2Terug_Click(object sender, RoutedEventArgs e)
        {
            if (hoedSpeler2 != 0)
            {
                hoedSpeler2 -= 1;
            }
            else
            {
                hoedSpeler2 = 4;
            }
            imgHoedS2.Source = maskerVeranderen(hoedSpeler2);
        }

        private void cboxS1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // als het niet is geladen, dan doet het deze code niet
            if (!isWindowLoaded) return;

            // zorgt ervoor dat alleen de text in de combobox wordt meegenomen in de string
            string k = cboxS1.SelectedItem.ToString();
            int index = k.IndexOf(" ");
            string kleur = k.Substring(index+1);
                imgRobotS1.Source = robotVeranderen(kleur);
        }

    private void cboxS2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // voor commentaar zie cboxS1_SelectionChanged
            if (!isWindowLoaded) return;

            string k = cboxS2.SelectedItem.ToString();
            int index = k.IndexOf(" ");
            string kleur = k.Substring(index + 1);
            imgRobotS2.Source = robotVeranderen(kleur);
        }

        private BitmapImage maskerVeranderen(int e)
        {
            //zorgt ervoor dat de character de goede helm heeft
            if (e == 0)
            {
                return new BitmapImage(new Uri("", UriKind.Relative));
            }
            else if (e == 1)
            {
                return new BitmapImage(new Uri("Resources/KerstmanHoed.png", UriKind.Relative));
            }
            else if (e == 2)
            {
                return new BitmapImage(new Uri("Resources/BouwvakkersHelm.png", UriKind.Relative));
            }
            else if (e == 3)
            {
                return new BitmapImage(new Uri("Resources/MaskerOranje.png", UriKind.Relative));
            }
            else if (e == 4)
            {
                return new BitmapImage(new Uri("Resources/MaskerPaars.png", UriKind.Relative));
            }
            else
            {
                return new BitmapImage(new Uri("", UriKind.Relative));
            }
        }

        private BitmapImage robotVeranderen(String e)
        {
            //zorgt ervoor dat de character de goede kleur heeft

            if (e.Equals("Blauw"))
            {
                return new BitmapImage(new Uri("Resources/BlauweRobot.png", UriKind.Relative));
            }
            else if (e == "Groen")
            {
                return new BitmapImage(new Uri("Resources/GroeneRobot.png", UriKind.Relative));
            }
            else if (e == "Geel")
            {
                return new BitmapImage(new Uri("Resources/GeleRobot.png", UriKind.Relative));
            }
            else if (e == "Roze")
            {
                return new BitmapImage(new Uri("Resources/RozeRobot.png", UriKind.Relative));
            }
            else
            {
                return new BitmapImage(new Uri("Resources/BlauweRobot.png", UriKind.Relative));
            }
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            LevelWindow levelWindow = new LevelWindow();
            levelWindow.Show();
            this.Close();
        }
    }
}
