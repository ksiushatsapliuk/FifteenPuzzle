using FifteenPuzzleCore.Interfaces;

namespace FifteenPuzzleCore.Models
{
    public class GameSolver : IGameSolver
    {
        private static readonly int[,] _directions = {
            { 0, -1 },
            { 1, 0 },
            { 0, 1 },
            { -1, 0 }
        };

        public async Task<List<Move>> FindSolutionAsync(int[,] state, int emptyX, int emptyY, CancellationToken cancellationToken)
        {
            int[,] currentState = (int[,])state.Clone();

            return await Task.Run(() => SolveWithAStar(currentState, emptyX, emptyY, cancellationToken), cancellationToken);
        }

        private List<Move> SolveWithAStar(int[,] initialState, int emptyX, int emptyY, CancellationToken cancellationToken)
        {
            var startNode = new PuzzleNode
            {
                State = initialState,
                EmptyX = emptyX,
                EmptyY = emptyY,
                Cost = 0,
                Heuristic = CalculateManhattanDistance(initialState),
                Parent = null,
                LastMove = null
            };

            var openSet = new PriorityQueue<PuzzleNode>();
            openSet.Enqueue(startNode, startNode.Cost + startNode.Heuristic);

            var closedSet = new Dictionary<string, PuzzleNode>();

            while (openSet.Count > 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var currentNode = openSet.Dequeue();
                string stateKey = GetStateKey(currentNode.State);

                if (closedSet.ContainsKey(stateKey))
                    continue;

                closedSet[stateKey] = currentNode;

                if (IsSolved(currentNode.State))
                {
                    return ReconstructPath(currentNode);
                }

                var neighbors = GenerateNeighbors(currentNode);

                foreach (var neighbor in neighbors)
                {
                    string neighborKey = GetStateKey(neighbor.State);

                    if (closedSet.ContainsKey(neighborKey))
                        continue;

                    openSet.Enqueue(neighbor, neighbor.Cost + neighbor.Heuristic);
                }
            }

            return new List<Move>();
        }

        private List<PuzzleNode> GenerateNeighbors(PuzzleNode node)
        {
            var neighbors = new List<PuzzleNode>();

            for (int i = 0; i < 4; i++)
            {
                int newX = node.EmptyX + _directions[i, 0];
                int newY = node.EmptyY + _directions[i, 1];

                if (newX >= 0 && newX < 4 && newY >= 0 && newY < 4)
                {
                    int[,] newState = (int[,])node.State.Clone();

                    newState[node.EmptyY, node.EmptyX] = newState[newY, newX];
                    newState[newY, newX] = 0;

                    var move = new Move(newX, newY);

                    var newNode = new PuzzleNode
                    {
                        State = newState,
                        EmptyX = newX,
                        EmptyY = newY,
                        Cost = node.Cost + 1,
                        Heuristic = CalculateManhattanDistance(newState),
                        Parent = node,
                        LastMove = move
                    };

                    neighbors.Add(newNode);
                }
            }

            return neighbors;
        }

        private int CalculateManhattanDistance(int[,] state)
        {
            int distance = 0;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int value = state[y, x];
                    if (value != 0) 
                    {
                        int targetX = (value - 1) % 4;
                        int targetY = (value - 1) / 4;

                        distance += Math.Abs(x - targetX) + Math.Abs(y - targetY);
                    }
                }
            }

            return distance;
        }

        private bool IsSolved(int[,] state)
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

        private List<Move> ReconstructPath(PuzzleNode node)
        {
            var path = new List<Move>();

            while (node.Parent != null)
            {
                path.Add(node.LastMove);
                node = node.Parent;
            }

            path.Reverse();
            return path;
        }

        private string GetStateKey(int[,] state)
        {
            var key = new System.Text.StringBuilder();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    key.Append(state[y, x]);
                    key.Append(',');
                }
            }
            return key.ToString();
        }

        private class PuzzleNode
        {
            public int[,] State { get; set; }
            public int EmptyX { get; set; }
            public int EmptyY { get; set; }
            public int Cost { get; set; } 
            public int Heuristic { get; set; } 
            public PuzzleNode Parent { get; set; }
            public Move LastMove { get; set; }
        }

        private class PriorityQueue<T>
        {
            private SortedDictionary<int, Queue<T>> _dictionary = new SortedDictionary<int, Queue<T>>();
            public int Count { get; private set; }

            public void Enqueue(T item, int priority)
            {
                if (!_dictionary.TryGetValue(priority, out Queue<T> queue))
                {
                    queue = new Queue<T>();
                    _dictionary[priority] = queue;
                }

                queue.Enqueue(item);
                Count++;
            }

            public T Dequeue()
            {
                if (Count == 0)
                    throw new InvalidOperationException("Queue is empty");

                var pair = _dictionary.First();
                var queue = pair.Value;
                var item = queue.Dequeue();

                if (queue.Count == 0)
                    _dictionary.Remove(pair.Key);

                Count--;
                return item;
            }
        }
    }
}