using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifteenPuzzleCore.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FifteenPuzzleCore.Interfaces
{
    public interface IGameSolver
    {
        Task<List<Move>> FindSolutionAsync(int[,] state, int emptyX, int emptyY, CancellationToken cancellationToken);
    }
}
