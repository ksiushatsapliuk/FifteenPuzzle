using FifteenPuzzleCore.EventArgs;
using FifteenPuzzleCore.Interfaces;
using FifteenPuzzleCore.Models;

namespace FifteenPuzzle
{
    internal class GameController
    {
        private readonly IGameBoard _gameBoard;
        private readonly IBoardGenerator _boardGenerator;
        private readonly IGameSolver _gameSolver;
        private readonly IRecordManager _recordManager;

        private CancellationTokenSource _autoSolveCTS;
        private bool _manuallyStoppedSolving = false;
        private Form _solverProgressForm;
        private ProgressBar _solverProgressBar;
        private Label _solverStatusLabel;

        public event EventHandler<BoardChangedEA> BoardChanged;
        public event EventHandler<GameWonEA> GameWon;
        public event EventHandler<EventArgs> AutoSolverStateChanged;

        public bool IsAutoSolving { get; private set; }
        public int BestRecord => _recordManager.BestRecord;

        public GameController(
            IGameBoard gameBoard,
            IBoardGenerator boardGenerator,
            IGameSolver gameSolver,
            IRecordManager recordManager)
        {
            _gameBoard = gameBoard;
            _boardGenerator = boardGenerator;
            _gameSolver = gameSolver;
            _recordManager = recordManager;

            _gameBoard.BoardChanged += (s, e) => BoardChanged?.Invoke(this, e);
            _gameBoard.GameWon += HandleGameWon;

            _recordManager.LoadRecord();
            InitializeProgressForm();
        }

        private void InitializeProgressForm()
        {
            _solverProgressForm = new Form
            {
                Text = "Solving Progress",
                Size = new System.Drawing.Size(400, 150),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = true,
                ShowInTaskbar = false
            };

            _solverStatusLabel = new Label
            {
                Text = "Searching for solution...",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };

            _solverProgressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new System.Drawing.Size(340, 30),
                Location = new System.Drawing.Point(20, 40)
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Size = new System.Drawing.Size(100, 30),
                Location = new System.Drawing.Point(140, 75)
            };

            cancelButton.Click += (s, e) =>
            {
                _manuallyStoppedSolving = true;
                CancelAutoSolve(showMessage: true);
                _solverProgressForm.Hide();
            };

            _solverProgressForm.Controls.Add(_solverStatusLabel);
            _solverProgressForm.Controls.Add(_solverProgressBar);
            _solverProgressForm.Controls.Add(cancelButton);

            _solverProgressForm.FormClosing += (s, e) =>
            {
                if (IsAutoSolving)
                {
                    _manuallyStoppedSolving = true;
                    CancelAutoSolve(showMessage: true);
                }
                e.Cancel = true; 
                _solverProgressForm.Hide();
            };
        }

        public void StartNewGame()
        {
            CancelAutoSolve(showMessage: false);

            var (state, emptyX, emptyY) = _boardGenerator.GenerateSolvableBoard();
            _gameBoard.Initialize(state, emptyX, emptyY);
        }

        public bool MakeTileMove(int x, int y)
        {
            if (IsAutoSolving)
                return false;

            return _gameBoard.MakeMove(x, y);
        }

        public async Task ToggleAutoSolveAsync()
        {
            try
            {
                if (IsAutoSolving)
                {
                    _manuallyStoppedSolving = true;
                    CancelAutoSolve(showMessage: true);
                }
                else
                {
                    await StartAutoSolveAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in ToggleAutoSolveAsync: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task StartAutoSolveAsync()
        {
            if (_gameBoard.IsComplete())
            {
                MessageBox.Show("Puzzle is already solved!", "Auto Solver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                IsAutoSolving = true;
                _gameBoard.SetSolving(true);
                _autoSolveCTS = new CancellationTokenSource();
                _manuallyStoppedSolving = false;
                OnAutoSolverStateChanged();
 
                _solverStatusLabel.Text = "Searching for solution...";
                _solverProgressBar.Style = ProgressBarStyle.Marquee;
                _solverProgressForm.Show();

                var currentState = _gameBoard.State;
                int emptyX = _gameBoard.EmptyX;
                int emptyY = _gameBoard.EmptyY;

                var solution = await _gameSolver.FindSolutionAsync(
                    currentState, emptyX, emptyY, _autoSolveCTS.Token);

                _solverProgressForm.Hide();

                if (_manuallyStoppedSolving)
                {
                    return;
                }

                if (solution == null || solution.Count == 0)
                {
                    MessageBox.Show(
                        "Could not find a solution for the current board state.",
                        "Auto Solver",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show($"Solution found with {solution.Count} moves. Starting execution.",
                   "Auto Solver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ExecuteSolutionAsync(solution, _autoSolveCTS.Token);

                if (!_gameBoard.IsComplete() && !_manuallyStoppedSolving)
                {
                    MessageBox.Show("Solution execution completed but the puzzle is not solved. There might be an issue with the solution algorithm.",
                        "Auto Solver", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (OperationCanceledException)
            {
                _solverProgressForm.Hide();
            }
            catch (Exception ex)
            {
                _solverProgressForm.Hide();
                MessageBox.Show(
                    $"An error occurred while solving: {ex.Message}\n{ex.StackTrace}",
                    "Auto Solver Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                IsAutoSolving = false;
                _gameBoard.SetSolving(false);
                OnAutoSolverStateChanged();
            }
        }

        private async Task ExecuteSolutionAsync(List<Move> solution, CancellationToken cancellationToken)
        {
            try
            {
                int moveCounter = 0;
                foreach (var move in solution)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    bool moveResult = _gameBoard.MakeMove(move.X, move.Y);

                    if (!moveResult)
                    {
                        MessageBox.Show($"Move at [{move.X}, {move.Y}] failed. Stopping auto-solver.",
                            "Auto Solver", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    await Task.Delay(300, cancellationToken);

                    Application.DoEvents();
                }
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing solution: {ex.Message}",
                    "Auto Solver Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelAutoSolve(bool showMessage = false)
        {
            if (_autoSolveCTS != null)
            {
                _autoSolveCTS.Cancel();
                _autoSolveCTS.Dispose();
                _autoSolveCTS = null;
            }

            IsAutoSolving = false;
            _gameBoard.SetSolving(false);
            OnAutoSolverStateChanged();

            if (showMessage && _manuallyStoppedSolving)
            {
                _solverProgressForm.Hide();
                MessageBox.Show("Auto-solving has been paused by user.",
                    "Auto Solver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleGameWon(object sender, GameWonEA e)
        {
            _recordManager.SaveRecord(e.MoveCount);
            GameWon?.Invoke(this, e);
        }

        private void OnAutoSolverStateChanged()
        {
            AutoSolverStateChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}