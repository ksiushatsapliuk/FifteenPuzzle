using FifteenPuzzleCore.Interfaces;
using System.Drawing;

namespace FifteenPuzzleCore.Models
{
    public class BoardGenerator : IBoardGenerator
    {
        private readonly Random _random = new Random();

        public (int[,] state, int emptyX, int emptyY) GenerateSolvableBoard()
        {
            int[,] state = new int[4, 4];
            int emptyX = 3;
            int emptyY = 3;

            do
            {
                int value = 1;
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        state[y, x] = value;
                        value++;
                    }
                }

                state[3, 3] = 0;
                emptyX = 3;
                emptyY = 3;

                ShuffleByRandomMoves(ref state, ref emptyX, ref emptyY, 200);
            }
            while (!IsSolvable(state, emptyY) || IsComplete(state));

            return (state, emptyX, emptyY);
        }

        private void ShuffleByRandomMoves(ref int[,] state, ref int emptyX, ref int emptyY, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                List<Point> possibleMoves = new List<Point>();

                if (emptyY > 0)
                    possibleMoves.Add(new Point(emptyX, emptyY - 1));

                if (emptyY < 3)
                    possibleMoves.Add(new Point(emptyX, emptyY + 1));

                if (emptyX > 0)
                    possibleMoves.Add(new Point(emptyX - 1, emptyY));

                if (emptyX < 3)
                    possibleMoves.Add(new Point(emptyX + 1, emptyY));

                if (possibleMoves.Count > 0)
                {
                    Point move = possibleMoves[_random.Next(possibleMoves.Count)];

                    state[emptyY, emptyX] = state[move.Y, move.X];
                    state[move.Y, move.X] = 0;

                    emptyX = move.X;
                    emptyY = move.Y;
                }
            }
        }

        private bool IsSolvable(int[,] state, int emptyY)
        {
            int[] flat = new int[16];
            int k = 0;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    flat[k++] = state[y, x];
                }
            }

            int inversions = 0;
            for (int i = 0; i < 16; i++)
            {
                if (flat[i] == 0) continue;

                for (int j = i + 1; j < 16; j++)
                {
                    if (flat[j] != 0 && flat[i] > flat[j])
                    {
                        inversions++;
                    }
                }
            }

            int emptyRowFromBottom = 4 - emptyY;

            return (emptyRowFromBottom % 2 == 1 && inversions % 2 == 0) ||
                   (emptyRowFromBottom % 2 == 0 && inversions % 2 == 1);
        }

        private bool IsComplete(int[,] state)
        {
            int expected = 1;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (y == 3 && x == 3)
                    {
                        if (state[y, x] != 0)
                            return false;
                    }
                    else if (state[y, x] != expected)
                    {
                        return false;
                    }
                    expected++;
                }
            }
            return true;
        }
    }
}