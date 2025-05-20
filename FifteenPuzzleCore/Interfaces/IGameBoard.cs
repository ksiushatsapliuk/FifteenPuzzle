using FifteenPuzzleCore.Enums;
using FifteenPuzzleCore.EventArgs;

namespace FifteenPuzzleCore.Interfaces
{
    public interface IGameBoard
    {
        event EventHandler<BoardChangedEA> BoardChanged;
        event EventHandler<GameWonEA> GameWon;

        int[,] State { get; }
        int EmptyX { get; }
        int EmptyY { get; }
        int MoveCount { get; }
        GameState CurrentState { get; }

        void Initialize(int[,] initialState, int emptyX, int emptyY);
        bool MakeMove(int x, int y);
        bool IsAdjacent(int x1, int y1, int x2, int y2);
        bool IsComplete();
        void SetSolving(bool isSolving);
    }
}