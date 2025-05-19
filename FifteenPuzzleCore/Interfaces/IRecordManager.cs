using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleCore.Interfaces
{
    public interface IRecordManager
    {
        int BestRecord { get; }
        void LoadRecord();
        void SaveRecord(int moveCount);
    }
}
