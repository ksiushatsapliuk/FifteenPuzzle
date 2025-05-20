namespace FifteenPuzzleCore.Interfaces
{
    public interface IBoardGenerator
    {
        (int[,] state, int emptyX, int emptyY) GenerateSolvableBoard();
    }
}
