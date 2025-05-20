namespace FifteenPuzzleCore.Interfaces
{
    public interface IRecordManager
    {
        int BestRecord { get; }
        void LoadRecord();
        void SaveRecord(int moveCount);
    }
}
