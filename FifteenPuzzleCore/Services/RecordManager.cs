using FifteenPuzzleCore.Interfaces;
using FifteenPuzzleCore.Utilities;

namespace FifteenPuzzleCore.Services
{
    public class RecordManager : IRecordManager
    {
        private readonly string _recordFilePath;

        public int BestRecord { get; private set; } = int.MaxValue;

        public RecordManager(string filePath = null)
        {
            _recordFilePath = filePath ?? ConstantsFP.DefaultRecordFilePath;
        }

        public void LoadRecord()
        {
            try
            {
                if (File.Exists(_recordFilePath))
                {
                    string content = File.ReadAllText(_recordFilePath);
                    if (int.TryParse(content, out int record))
                    {
                        BestRecord = record;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        public void SaveRecord(int moveCount)
        {
            if (moveCount < BestRecord)
            {
                BestRecord = moveCount;
                try
                {
                    File.WriteAllText(_recordFilePath, BestRecord.ToString());
                }
                catch (Exception)
                {
                     
                }
            }
        }
    }
}
