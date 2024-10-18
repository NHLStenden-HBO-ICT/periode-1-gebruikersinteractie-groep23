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
using System.Windows.Threading;
namespace game_7_8
{
    /// <summary>
    /// Interaction logic for Level1Window.xaml
    /// </summary>
    public partial class Level1Window : Window
    {

        bool Player_jump;
        int speed = 12;
        int score = 0;
        double playerSpeed = 8;
        int jumpSpeed = 16;
        int gravity = 1;
        bool isJumping = false;
        int velocityY = 0;
        bool onPlatform;

        Rect playerHitbox;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight;

        public Level1Window()
        {
            InitializeComponent();

            GameCanvas.Focus();

            gameTimer = new DispatcherTimer();
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }
        private void GameLoop(object sender, EventArgs e)

        {
            // Speler beweging en zwaartekracht
            velocityY += gravity;
            if (isJumping)
            {
                
                Canvas.SetTop(Player, Canvas.GetTop(Player) + velocityY);
            }
            if (goLeft == true && Canvas.GetLeft(Player) > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
            }
            if (Application.Current.MainWindow != null)
            {
                if (goRight == true && Canvas.GetLeft(Player) + (Player.Width + 20) < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
                }
                Canvas.SetTop(Player, Canvas.GetTop(Player) + velocityY);

                if (Canvas.GetTop(Player) + (Player.Height * 0.1) > Application.Current.MainWindow.Height)
                {
                    Canvas.SetTop(Player, -80);
                }
            }
            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {
                Rect playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if ((string)x.Tag == "Platform")
                {
                    x.Stroke = Brushes.Black;
                   
                    if (playerHitBox.IntersectsWith(platformHitBox) && velocityY >= 0)
                    {
                        if (Canvas.GetTop(Player) + Player.Height <= Canvas.GetTop(x) + 5)
                        {
                            velocityY = 0;
                            Canvas.SetTop(Player, Canvas.GetTop(x) - Player.Height);
                            isJumping = false;
                            onPlatform = true;
                        }

                    }
                }
                if ((string)x.Tag == "Exit")
                {
                    if (playerHitBox.IntersectsWith(platformHitBox))
                    {
                        gameTimer.Stop();
                    }
                }
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;
            }
            if (e.Key == Key.Up)
            {
                isJumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
            }
            if (e.Key == Key.Up && !isJumping)
            {
                isJumping = false;
                velocityY = -jumpSpeed;
            }
        }
    }
}