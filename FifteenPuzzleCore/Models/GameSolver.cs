using FifteenPuzzleCore.Interfaces;

namespace FifteenPuzzleCore.Models
{
    public class GameSolver : IGameSolver
    {
        // Допустимі напрямки руху (вгору, вправо, вниз, вліво)
        private static readonly int[,] _directions = {
            { 0, -1 }, // Вгору
            { 1, 0 },  // Вправо
            { 0, 1 },  // Вниз
            { -1, 0 }  // Вліво
        };

        public async Task<List<Move>> FindSolutionAsync(int[,] state, int emptyX, int emptyY, CancellationToken cancellationToken)
        {
            // Створюємо копію стану для роботи алгоритму
            int[,] currentState = (int[,])state.Clone();

            // Використовуємо A* алгоритм для знаходження рішення
            return await Task.Run(() => SolveWithAStar(currentState, emptyX, emptyY, cancellationToken), cancellationToken);
        }

        private List<Move> SolveWithAStar(int[,] initialState, int emptyX, int emptyY, CancellationToken cancellationToken)
        {
            // Початковий стан вузла
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

            // Відкрита множина (вузли для дослідження)
            var openSet = new PriorityQueue<PuzzleNode>();
            openSet.Enqueue(startNode, startNode.Cost + startNode.Heuristic);

            // Закрита множина (вже досліджені стани)
            var closedSet = new Dictionary<string, PuzzleNode>();

            while (openSet.Count > 0)
            {
                // Перевіряємо, чи не скасовано операцію
                cancellationToken.ThrowIfCancellationRequested();

                // Отримуємо вузол з найменшою оцінкою f = g + h
                var currentNode = openSet.Dequeue();
                string stateKey = GetStateKey(currentNode.State);

                // Якщо вже досліджували цей стан, продовжуємо
                if (closedSet.ContainsKey(stateKey))
                    continue;

                // Додаємо поточний стан до закритої множини
                closedSet[stateKey] = currentNode;

                // Перевіряємо, чи досягли цільового стану
                if (IsSolved(currentNode.State))
                {
                    // Відновлюємо шлях
                    return ReconstructPath(currentNode);
                }

                // Генеруємо наступні можливі стани
                var neighbors = GenerateNeighbors(currentNode);

                foreach (var neighbor in neighbors)
                {
                    string neighborKey = GetStateKey(neighbor.State);

                    // Пропускаємо стани, які вже досліджували
                    if (closedSet.ContainsKey(neighborKey))
                        continue;

                    // Додаємо сусіда до відкритої множини
                    openSet.Enqueue(neighbor, neighbor.Cost + neighbor.Heuristic);
                }
            }

            // Рішення не знайдено
            return new List<Move>();
        }

        private List<PuzzleNode> GenerateNeighbors(PuzzleNode node)
        {
            var neighbors = new List<PuzzleNode>();

            for (int i = 0; i < 4; i++)
            {
                int newX = node.EmptyX + _directions[i, 0];
                int newY = node.EmptyY + _directions[i, 1];

                // Перевіряємо, чи нова позиція в межах дошки
                if (newX >= 0 && newX < 4 && newY >= 0 && newY < 4)
                {
                    // Створюємо копію поточного стану
                    int[,] newState = (int[,])node.State.Clone();

                    // Міняємо місцями порожню клітинку та сусідню
                    newState[node.EmptyY, node.EmptyX] = newState[newY, newX];
                    newState[newY, newX] = 0;

                    // Створюємо новий хід
                    var move = new Move(newX, newY);

                    // Створюємо новий вузол
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
                    if (value != 0) // Ігноруємо порожню клітинку
                    {
                        // Визначаємо цільову позицію для числа
                        int targetX = (value - 1) % 4;
                        int targetY = (value - 1) / 4;

                        // Додаємо відстань між поточною та цільовою позиціями
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
                    // Остання клітинка має бути порожньою
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

            // Проходимо назад від цільового вузла до початкового
            while (node.Parent != null)
            {
                path.Add(node.LastMove);
                node = node.Parent;
            }

            // Перевертаємо шлях, щоб отримати послідовність ходів від початку до кінця
            path.Reverse();
            return path;
        }

        private string GetStateKey(int[,] state)
        {
            // Перетворюємо стан на рядок для зручного порівняння
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

        // Внутрішній клас для вузла в алгоритмі A*
        private class PuzzleNode
        {
            public int[,] State { get; set; }
            public int EmptyX { get; set; }
            public int EmptyY { get; set; }
            public int Cost { get; set; }        // g - вартість шляху від початку
            public int Heuristic { get; set; }   // h - евристична оцінка до цілі
            public PuzzleNode Parent { get; set; }
            public Move LastMove { get; set; }
        }

        // Пріоритетна черга для A* алгоритму
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