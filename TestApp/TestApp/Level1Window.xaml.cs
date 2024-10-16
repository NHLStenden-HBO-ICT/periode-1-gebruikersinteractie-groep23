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
        int Force;
        int Gravity;
        bool Player_jump;
        int speed = 12;
        int score = 0;
        double playerSpeed = 8;
        double jumpSpeed = 12;
        double gravity = 0.5;
        bool isJumping = false;
        double velocityY = 0;
        Rect playerHitbox;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight;

        public Level1Window()
        {
            InitializeComponent();

            GameCanvas.Focus();
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
        {
            // Speler beweging en zwaartekracht
            if (isJumping)
            {
                velocityY += gravity;
                Canvas.SetTop(Player, Canvas.GetTop(Player) + velocityY);
            }

            // Collision met platformen
            CheckCollisionWithPlatforms();

            // Collision met coins
            CheckCollisionWithCoins();

            // Beweeg vijanden
            MoveEnemies();

            // Collision met vijanden
            CheckCollisionWithEnemies();

            // Check als speler bij de deur is en alle coins heeft verzameld
            CheckIfGameWon();
        }

        private void CheckCollisionWithPlatforms()
        {
            foreach (var element in GameCanvas.Children)
            {
                if (element is Rectangle platform && platform.Fill.ToString() == "Brown")
                {
                    playerHitbox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                    Rect platformHitbox = new Rect(Canvas.GetLeft(platform), Canvas.GetTop(platform), platform.Width, platform.Height);

                    if (playerHitbox.IntersectsWith(platformHitbox))
                    {
                        velocityY = 0;
                        isJumping = false;
                        Canvas.SetTop(Player, Canvas.GetTop(platform) - Player.Height);
                    }
                }
            }
        }

        private void CheckCollisionWithCoins()
        {
            if (Player == null) return;

            foreach (var element in GameCanvas.Children)
            {
                if (element is Rectangle coin && coin.Tag != null && coin.Tag.ToString() == "Coin")
                {
                    Rect coinHitbox = new Rect(Canvas.GetLeft(coin), Canvas.GetTop(coin), coin.Width, coin.Height);
                    Rect playerHitbox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

                    if (playerHitbox.IntersectsWith(coinHitbox))
                    {
                        GameCanvas.Children.Remove(coin); // Verwijder de coin
                        score++;
                        ScoreText.Text = "Score: " + score;
                    }
                }
            }
        }

        private void CheckCollisionWithEnemies()
        {
            foreach (var element in GameCanvas.Children)
            {
                if (element is Rectangle enemy && enemy.Fill.ToString() == "Pink")
                {
                    Rect enemyHitbox = new Rect(Canvas.GetLeft(enemy), Canvas.GetTop(enemy), enemy.Width, enemy.Height);
                    playerHitbox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

                    if (playerHitbox.IntersectsWith(enemyHitbox))
                    {
                        MessageBox.Show("You died!");
                        ResetGame();
                    }
                }
            }
        }

        private void MoveEnemies()
        {
            // Beweeg de vijanden van links naar rechts
            double speed = 5;
            Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) + speed);
            Canvas.SetLeft(Enemy2, Canvas.GetLeft(Enemy2) + speed);

            if (Canvas.GetLeft(Enemy1) > GameCanvas.ActualWidth - Enemy1.Width || Canvas.GetLeft(Enemy1) < 0)
            {
                speed = -speed; // Keer de richting om
            }
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