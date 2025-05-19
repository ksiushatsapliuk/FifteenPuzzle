using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleCore.Interfaces
{
    public interface IBoardGenerator
    {
        (int[,] state, int emptyX, int emptyY) GenerateSolvableBoard();
    }
}
