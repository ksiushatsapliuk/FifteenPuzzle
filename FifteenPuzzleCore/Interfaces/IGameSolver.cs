using FifteenPuzzleCore.Models;

namespace FifteenPuzzleCore.Interfaces
{
    public interface IGameSolver
    {
        Task<List<Move>> FindSolutionAsync(int[,] state, int emptyX, int emptyY, CancellationToken cancellationToken);
    }
}
