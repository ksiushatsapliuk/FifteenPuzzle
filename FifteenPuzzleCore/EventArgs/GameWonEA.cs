namespace FifteenPuzzleCore.EventArgs
{
    public class GameWonEA : System.EventArgs
    {
        public int MoveCount { get; }

        public GameWonEA(int moveCount)
        {
            MoveCount = moveCount;
        }
    }
}