
namespace TicTacToe.Logic
{
    public class TicTacToeGame
    {
        #region Player
        private Player[] _players;
        private int _currentPlayerIndex;
        #endregion

        private static readonly int BOARD_SIZE = 3;
        private readonly char[,,] _gameBoard;

        public int BoardSize => _gameBoard.GetLength(0);
        public Player? Winner => GetWinner();
        public Player CurrentPlayer
        {
            get { return _players[_currentPlayerIndex]; }
        }
        public bool IsGameOver
        {
            get { return Winner != null || IsBoardFull(); }
        }

        public TicTacToeGame(params Player[] players)
        {
            _gameBoard = new char[BOARD_SIZE, BOARD_SIZE, BOARD_SIZE];
            _players = players;
            _currentPlayerIndex = 0;
        }

        public void MakeMove(PositionPoint point)
        {
            if (IsGameOver)
            {
                throw new Exception("The game is already over.");
            }

            int x = point.X;
            int y = point.Y;
            int z = point.Z;

            if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize || z < 0 || z >= BoardSize)
            {
                throw new ArgumentOutOfRangeException("The coordinates are out of bounds.");
            }
            if (_gameBoard[x, y, z] != '\0')
            {
                throw new Exception("The cell is already occupied.");
            }

            _gameBoard[x, y, z] = CurrentPlayer.Symbol;
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Length;
        }

        // TODO: Implement winner calculation
        private Player? GetWinner()
        {
            //// Check rows
            //for (int i = 0; i < 3; i++)
            //{
            //    if (_gameBoard[i, 0, 0] == _gameBoard[i, 1, 0] && _gameBoard[i, 1, 0] == _gameBoard[i, 2, 0])
            //    {
            //        return _players.FirstOrDefault(p => p.Symbol == _gameBoard[i, 0, 0]);
            //    }
            //}

            //// Check columns
            //for (int i = 0; i < 3; i++)
            //{
            //    if (_gameBoard[0, i, 0] == _gameBoard[1, i, 0] && _gameBoard[1, i, 0] == _gameBoard[2, i, 0])
            //    {
            //        return _players.FirstOrDefault(p => p.Symbol == _gameBoard[0, i, 0]);
            //    }
            //}

            //// Check diagonals
            //if (_gameBoard[0, 0, 0] == _gameBoard[1, 1, 0] && _gameBoard[1, 1, 0] == _gameBoard[2, 2, 0])
            //{
            //    return _players.FirstOrDefault(p => p.Symbol == _gameBoard[0, 0, 0]);
            //}
            //if (_gameBoard[0, 2, 0] == _gameBoard[1, 1, 0] && _gameBoard[1, 1, 0] == _gameBoard[2, 0, 0])
            //{
            //    return _players.FirstOrDefault(p => p.Symbol == _gameBoard[0, 2, 0]);
            //}

            return null;
        }
    
        private bool IsBoardFull()
        {
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    for (int z = 0; z < BoardSize; z++)
                    {
                        if (_gameBoard[x, y, z] == '\0')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}