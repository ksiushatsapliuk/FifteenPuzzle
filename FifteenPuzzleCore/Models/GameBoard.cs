using System;
using FifteenPuzzleCore.Enums;
using FifteenPuzzleCore.EventArgs;
using FifteenPuzzleCore.Interfaces;

namespace FifteenPuzzleCore.Models
{
    public class GameBoard : IGameBoard
    {
        public event EventHandler<BoardChangedEA> BoardChanged;
        public event EventHandler<GameWonEA> GameWon;

        private int[,] _state = new int[4, 4];
        private int _emptyX;
        private int _emptyY;
        private int _moveCount = 0;
        private bool _isSolving = false;

        public int[,] State => (int[,])_state.Clone();
        public int EmptyX => _emptyX;
        public int EmptyY => _emptyY;
        public int MoveCount => _moveCount;
        public GameState CurrentState { get; private set; } = GameState.InProgress;

        public void Initialize(int[,] initialState, int emptyX, int emptyY)
        {
            _state = (int[,])initialState.Clone();
            _emptyX = emptyX;
            _emptyY = emptyY;
            _moveCount = 0;
            _isSolving = false;
            CurrentState = GameState.InProgress;
            OnBoardChanged();
        }

        public bool MakeMove(int x, int y)
        {
            // Дозволяємо хід тільки якщо плитка поруч з порожньою клітинкою
            if (!IsAdjacent(x, y, _emptyX, _emptyY))
                return false;

            // Якщо гра завершена і ми не в режимі автоматичного вирішення, не дозволяємо ходи
            if (CurrentState == GameState.Completed && !_isSolving)
                return false;

            // Swap the tile with the empty cell
            _state[_emptyY, _emptyX] = _state[y, x];
            _state[y, x] = 0;

            // Update empty position
            _emptyX = x;
            _emptyY = y;

            // Increment move counter
            _moveCount++;

            // Повідомляємо про зміну дошки
            OnBoardChanged();

            // Check if the game is complete
            if (IsComplete() && CurrentState != GameState.Completed)
            {
                CurrentState = GameState.Completed;
                OnGameWon(_moveCount);
            }

            return true;
        }

        public bool IsAdjacent(int x1, int y1, int x2, int y2)
        {
            // Check if two cells are adjacent (horizontally or vertically)
            return (Math.Abs(x1 - x2) == 1 && y1 == y2) || (Math.Abs(y1 - y2) == 1 && x1 == x2);
        }

        public bool IsComplete()
        {
            // Check if the puzzle is in its solved state
            int expected = 1;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // The last cell should be empty (0)
                    if (y == 3 && x == 3)
                    {
                        if (_state[y, x] != 0)
                            return false;
                    }
                    else if (_state[y, x] != expected)
                    {
                        return false;
                    }
                    expected++;
                }
            }
            return true;
        }

        public void SetSolving(bool isSolving)
        {
            _isSolving = isSolving;
            CurrentState = isSolving ? GameState.Solving : (IsComplete() ? GameState.Completed : GameState.InProgress);
            OnBoardChanged(); // Повідомляємо про зміну стану
        }

        protected virtual void OnBoardChanged()
        {
            BoardChanged?.Invoke(this, new BoardChangedEA(_state, _moveCount));
        }

        protected virtual void OnGameWon(int moveCount)
        {
            GameWon?.Invoke(this, new GameWonEA(moveCount));
        }
    }
}