using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestApp
{
    class Globals
    {
        public static class PlayerInfo
        {
            public static string spelerNaam1 { get; set; }
            public static string spelerNaam2 { get; set; }
        }

        public static class GlobalGeluid
        {
            public static int muziekVolume = 100;
            public static int effectenVolume = 100;
            public static bool optiesGeopend = false;
            public static bool muziekAan = false;
        }
    }
       

        public class BackgroundMusicPlayer
        {
            private static BackgroundMusicPlayer _instance;
            private MediaPlayer _mediaPlayer;

            private BackgroundMusicPlayer()
            {
                _mediaPlayer = new MediaPlayer();
                _mediaPlayer.Open(new Uri("Resources/Background_Muziek.mp3", UriKind.RelativeOrAbsolute));
                _mediaPlayer.MediaEnded += (sender, e) => _mediaPlayer.Position = TimeSpan.Zero; // Loop the music
                _mediaPlayer.MediaOpened += (sender, e) => Console.WriteLine("Media opened successfully.");
                _mediaPlayer.MediaFailed += (sender, e) => Console.WriteLine($"Media failed: {e.ErrorException.Message}");
            }

            public static BackgroundMusicPlayer Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new BackgroundMusicPlayer();
                    }
                    return _instance;
                }
            }

            public void Play()
            {
                _mediaPlayer.Volume = 1; // Set initial volume
                _mediaPlayer.Play();
            }

            public void Stop()
            {
                _mediaPlayer.Stop();
            }

            public void SetVolume(double volume)
            {
                _mediaPlayer.Volume = volume;
            }
        }

    }
public static class PlayerInfo
{
    public static string spelerNaam1 { get; set; }
    public static string spelerNaam2 { get; set; }
}
