using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
using TestApp;
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
        double player2Speed = 8;
        int jumpSpeed = 16;
        int jumpSpeed2 = 16;
        int gravity = 1;
        int gravity2 = 1;
        bool isJumping = false;
        bool isJumping2 = false;
        int velocityY = 0;
        int velocityY2 = 0;
        bool onPlatform;
        bool onPlatform2;


        Rect playerHitbox;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight;
        bool goLeft2, goRight2;

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
            if (velocityY < 6)
                velocityY += gravity;
            else
                velocityY = 4;
            if (goLeft == true && Canvas.GetLeft(Player1) > 5)
            {
                Canvas.SetLeft(Player1, Canvas.GetLeft(Player1) - playerSpeed);
            }
            if (Application.Current.MainWindow != null)
            {
                if (goRight == true && Canvas.GetLeft(Player1) + (Player1.Width + 20) < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(Player1, Canvas.GetLeft(Player1) + playerSpeed);
                }
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) + velocityY);

                if (Canvas.GetTop(Player1) + (Player1.Height * 0.1) > Application.Current.MainWindow.Height)
                {
                    Canvas.SetLeft(Player1, 25);
                    Canvas.SetTop(Player1, 790);
                }
            }
            if (velocityY2 < 6)
                velocityY2 += gravity;
            if (isJumping2)
            {
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) + velocityY2);
            }
            if (goLeft2 && Canvas.GetLeft(Player2) > 5)
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) - player2Speed);
            }
            if (Application.Current.MainWindow != null)
            {
                if (goRight2 && Canvas.GetLeft(Player2) + (Player2.Width + 20) < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) + player2Speed);
                }
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) + velocityY2);

                if (Canvas.GetTop(Player2) + (Player2.Height * 0.1) > Application.Current.MainWindow.Height)
                {
                    Canvas.SetLeft(Player2, 112);
                    Canvas.SetTop(Player2, 790);
                }
            }

            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {
                Rect playerHitBox = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
                Rect player2HitBox = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
                Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if ((string)x.Tag == "Platform")
                {
                    x.Stroke = Brushes.Black;

                    if (playerHitBox.IntersectsWith(platformHitBox) && velocityY >= 0)
                    {
                        if (Canvas.GetTop(Player1) + Player1.Height <= Canvas.GetTop(x) + 5)
                        {
                            velocityY = 0;
                            Canvas.SetTop(Player1, Canvas.GetTop(x) - Player1.Height);
                            isJumping = false;
                            onPlatform = true;
                        }

                    }
                    if (player2HitBox.IntersectsWith(platformHitBox) && velocityY2 >= 0)
                    {
                        if (Canvas.GetTop(Player2) + Player2.Height <= Canvas.GetTop(x) + 5)
                        {
                            velocityY2 = 0;
                            Canvas.SetTop(Player2, Canvas.GetTop(x) - Player2.Height);
                            isJumping2 = false;
                            onPlatform2 = true;
                        }

                    }
                    
                }
                if ((string)x.Tag == "Exit")
                {
                    x.Stroke = Brushes.Black;

                    if (playerHitBox.IntersectsWith(platformHitBox) && player2HitBox.IntersectsWith(platformHitBox))
                    {
                        EindScherm eindScherm = new EindScherm();
                        gameTimer.Stop();
                        eindScherm.Show();
                        this.Close();
                    }
                }
            }
            if (isJumping)
            {

                Canvas.SetTop(Player1, Canvas.GetTop(Player1) + velocityY);
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
            if (e.Key == Key.A)
            {
                goLeft2 = false;
            }
            if (e.Key == Key.D)
            {
                goRight2 = false;
            }
            if (e.Key == Key.W && !isJumping2)
            {
                isJumping2 = false;
                velocityY2 = -jumpSpeed;
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
            if (e.Key == Key.A)
            {
                goLeft2 = true;
            }
            if (e.Key == Key.D)
            {
                goRight2 = true;
            }
            if (e.Key == Key.W)
            {
                isJumping2 = true;
            }

        }
    }
}