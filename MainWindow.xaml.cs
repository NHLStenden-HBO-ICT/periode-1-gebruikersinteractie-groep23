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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int score = 0;
        private double playerSpeed = 10;
        private double jumpSpeed = 15;
        private double gravity = 0.5;
        private bool isJumping = false;
        private double velocityY = 0;
        private Rect playerHitbox;
        private DispatcherTimer gameTimer;

        public MainWindow()
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Speler beweging links/rechts
            if (e.Key == Key.Left)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
            }
            else if (e.Key == Key.Right)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
            }
            else if (e.Key == Key.Space && !isJumping)
            {
                isJumping = true;
                velocityY = -jumpSpeed;
            }
        }
    }
}