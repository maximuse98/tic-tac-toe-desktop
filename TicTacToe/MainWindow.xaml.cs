using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TicTacToe.Components;
using TicTacToe.Logic;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TicTacToeGame _gameLogic;

        // use it to define players
        private static Player[] players =
        [
            new("Player 1", Brushes.Red, 'X'), 
            new("Player 2", Brushes.Blue, 'O'),
            new("Player 3", Brushes.Green, 'Y')
        ];

        public MainWindow()
        {
            InitializeComponent();

            _gameLogic = new TicTacToeGame(players);
        }

        private void OnMoveClicked(object sender, RoutedEventArgs e)
        {
            MoveSelector selector = (MoveSelector)sender;

            // Show the player symbol and color on the clicked button
            selector.ClickedButton.Content = _gameLogic.CurrentPlayer.Symbol;
            selector.ClickedButton.Background = _gameLogic.CurrentPlayer.Color;

            PositionPoint cubeLocation = new (
                int.Parse(selector.RowPosition),
                CoordinateHelper.GetY(selector.ClickedButton.Name),
                CoordinateHelper.GetZ(selector.ClickedButton.Name));

            // Find the cube image and make it visible
            Image cubeImage = (Image)this.FindName($"cube_{cubeLocation}");
            cubeImage.Source = _gameLogic.CurrentPlayer.CubeImage;
            cubeImage.Visibility = Visibility.Visible;

            _gameLogic.MakeMove(cubeLocation);

            if (_gameLogic.IsGameOver)
            {
                if (_gameLogic.Winner == null)
                {
                    MessageBox.Show("The game ended in a draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Player {_gameLogic.Winner.Name} won the game!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                Application.Current.Shutdown();
                return;
            }
        }
    }
}