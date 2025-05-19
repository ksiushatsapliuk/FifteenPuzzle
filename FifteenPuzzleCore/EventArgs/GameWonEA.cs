using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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