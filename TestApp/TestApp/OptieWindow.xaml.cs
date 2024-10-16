﻿using System;
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
        public int effectenVoorStil;
        public int MuziekVoorStil;
        public OptieWindow()
        {
            InitializeComponent();
            sliderEffecten.Value = Globals.GlobalGeluid.effectenVolume;
            sliderMuziek.Value = Globals.GlobalGeluid.muziekVolume;
        }

        private void sliderEffecten_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Globals.GlobalGeluid.effectenVolume = Convert.ToInt32(sliderEffecten.Value) ;
            txtEffecten.Text = Convert.ToString(sliderEffecten.Value);
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
            BackgroundMusicPlayer.Instance.SetVolume((sliderMuziek.Value / 100));
            txtMuziek.Text = Convert.ToString(sliderMuziek.Value);
        }

        private void btnEffecten_Click(object sender, RoutedEventArgs e)
        {
            if(sliderEffecten.Value != 0)
            {
                effectenVoorStil = Convert.ToInt32(sliderEffecten.Value);
                sliderEffecten.Value = 0;
                btnEffectenimg.Source = new BitmapImage(new Uri("Resources/imgEffectenUit.png", UriKind.Relative));
            }
            else
            {
                sliderEffecten.Value = effectenVoorStil;
                btnEffectenimg.Source = new BitmapImage(new Uri("Resources/imgEffectenAan.png", UriKind.Relative));
            }
        }

        private void btnMuziek_Click(object sender, RoutedEventArgs e)
        {
            if (sliderMuziek.Value != 0)
            {
                MuziekVoorStil = Convert.ToInt32(sliderMuziek.Value);
                sliderMuziek.Value = 0;
               BtnMuziekimg.Source = new BitmapImage(new Uri("Resources/imgMuziekUit.png", UriKind.Relative));
                BackgroundMusicPlayer.Instance.SetVolume((sliderMuziek.Value / 100));

            }
            else
            {
                sliderMuziek.Value = MuziekVoorStil;
               BtnMuziekimg.Source = new BitmapImage(new Uri("Resources/imgMuziekAan.png", UriKind.Relative));
                BackgroundMusicPlayer.Instance.SetVolume((sliderMuziek.Value / 100));
            }
        }
    }
    
}
