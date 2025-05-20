namespace FifteenPuzzleCore.Models
{
    public class Move
    {
        public int X { get; }
        public int Y { get; }

        public Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}