namespace FifteenPuzzleCore.EventArgs
{
    public class BoardChangedEA : System.EventArgs
    {
        public int[,] BoardState { get; }
        public int MoveCount { get; }

        public BoardChangedEA(int[,] boardState, int moveCount)
        {
            BoardState = boardState;
            MoveCount = moveCount;
        }
    }
}