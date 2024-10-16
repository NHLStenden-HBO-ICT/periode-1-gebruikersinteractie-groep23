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
<<<<<<< HEAD
=======
        int Force;
        int Gravity;
>>>>>>> f2d6984b048d846a4d0515b0cb23ffa301cf6b54
        bool Player_jump;
        int speed = 12;
        int score = 0;
        double playerSpeed = 8;
<<<<<<< HEAD
        int jumpSpeed = 12;
        int gravity = 1;
        bool isJumping = false;
        int velocityY = 0;
=======
        double jumpSpeed = 12;
        double gravity = 0.5;
        bool isJumping = false;
        double velocityY = 0;
>>>>>>> f2d6984b048d846a4d0515b0cb23ffa301cf6b54
        Rect playerHitbox;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight;

        public Level1Window()
        {
            InitializeComponent();

            GameCanvas.Focus();
<<<<<<< HEAD
            gameTimer = new DispatcherTimer();
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }



        private void GameLoop(object? sender, EventArgs e)
=======
            gameTimer.Tick += GameLoop;
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Start();
        }

        private void GameTimerEvent(object? sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(Player) > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
            }
            if (goRight == true && Canvas.GetLeft(Player) + (Player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
            }
        }

        private void GameLoop(object sender, EventArgs e)
>>>>>>> f2d6984b048d846a4d0515b0cb23ffa301cf6b54
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

                if (Canvas.GetTop(Player) + (Player.Height * 2) > Application.Current.MainWindow.Height)
                {
                    Canvas.SetTop(Player, -80);
                }
            }
            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "Platform")
                {
                    x.Stroke = Brushes.Black;
                    Rect playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                    Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(platformHitBox) && velocityY >=0)
                    {
                        if (Canvas.GetTop(Player) + Player.Height <= Canvas.GetTop(x) + 5)
                        {
                            velocityY = 0;
                            Canvas.SetTop(Player, Canvas.GetTop(x) - Player.Height);
                            isJumping = false;
                        }
                         
                    }
                }
            }
            // Check als speler bij de deur is en alle coins heeft verzameld
            CheckIfGameWon();
        }

        private void CheckIfGameWon()
        {
            if (score == 4) // Alle coins verzameld
            {
                Rect doorHitbox = new Rect(Canvas.GetLeft(Door), Canvas.GetTop(Door), Door.Width, Door.Height);
                playerHitbox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

                if (playerHitbox.IntersectsWith(doorHitbox))
                {
                    MessageBox.Show("You win!");
                    ResetGame();
                }
            }
        }

        private void ResetGame()
        {
            score = 0;
            ScoreText.Text = "Score: 0";
            Canvas.SetLeft(Player, 300);
            Canvas.SetTop(Player, 500);
            // Reset de coins en vijanden indien nodig
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
            if (e.Key == Key.Space)
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
            if (e.Key == Key.Space && !isJumping)
            {
                isJumping = false;
                velocityY = -jumpSpeed;
            }
        }
    }
}