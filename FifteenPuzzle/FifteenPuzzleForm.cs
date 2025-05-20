using FifteenPuzzleCore.EventArgs;
using FifteenPuzzleCore.Models;
using FifteenPuzzleCore.Services;

namespace FifteenPuzzle
{
    public partial class FifteenPuzzleForm : Form
    {
        private readonly GameController _gameController;
        private readonly Button[,] _buttons = new Button[4, 4];

        public FifteenPuzzleForm()
        {
            InitializeComponent();

            SetupButtonMatrix();

            var gameBoard = new GameBoard();
            var boardGenerator = new BoardGenerator();
            var gameSolver = new GameSolver();
            var recordManager = new RecordManager();

            _gameController = new GameController(
                gameBoard,
                boardGenerator,
                gameSolver,
                recordManager);

            _gameController.BoardChanged += OnBoardChanged;
            _gameController.GameWon += OnGameWon;
            _gameController.AutoSolverStateChanged += OnAutoSolverStateChanged;

            SetupTileClickHandlers();
        }

        private void SetupButtonMatrix()
        {
            _buttons[0, 0] = button1;
            _buttons[0, 1] = button2;
            _buttons[0, 2] = button3;
            _buttons[0, 3] = button4;
            _buttons[1, 0] = button5;
            _buttons[1, 1] = button6;
            _buttons[1, 2] = button7;
            _buttons[1, 3] = button8;
            _buttons[2, 0] = button9;
            _buttons[2, 1] = button10;
            _buttons[2, 2] = button11;
            _buttons[2, 3] = button12;
            _buttons[3, 0] = button13;
            _buttons[3, 1] = button14;
            _buttons[3, 2] = button15;
            _buttons[3, 3] = button16;
        }

        private void SetupTileClickHandlers()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int capturedX = x;
                    int capturedY = y;
                    _buttons[y, x].Click += (sender, e) => TileButton_Click(capturedX, capturedY);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateRecordDisplay();
            _gameController.StartNewGame();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            _gameController.StartNewGame();
        }

        private async void solveButton_Click(object sender, EventArgs e)
        {
            try
            {
                await _gameController.ToggleAutoSolveAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Auto Solve: {ex.Message}\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBoardChanged(object sender, BoardChangedEA e)
        {
            try
            {
                UpdateBoardDisplay(e.BoardState);
                UpdateMoveCounter(e.MoveCount);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating board: {ex.Message}",
                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnGameWon(object sender, GameWonEA e)
        {
            UpdateRecordDisplay();
            MessageBox.Show($"Congratulations! You solved the puzzle in {e.MoveCount} moves.",
                "Puzzle Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnAutoSolverStateChanged(object sender, EventArgs e)
        {
            UpdateUIForAutoSolving();
        }

        private void TileButton_Click(int x, int y)
        {
            _gameController.MakeTileMove(x, y);
        }

        private void UpdateBoardDisplay(int[,] state)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int value = state[y, x];
                    _buttons[y, x].Text = value == 0 ? "" : value.ToString();
                    _buttons[y, x].Enabled = value != 0;
                }
            }
        }

        private void UpdateMoveCounter(int moveCount)
        {
            moveCounterLabel.Text = $"Moves: {moveCount}";
        }

        private void UpdateRecordDisplay()
        {
            int record = _gameController.BestRecord;
            recordLabel.Text = record < int.MaxValue
                ? $"Record: {record} moves"
                : "Record: N/A";
        }

        private void UpdateUIForAutoSolving()
        {
            bool isSolving = _gameController.IsAutoSolving;
            solveButton.Text = isSolving ? "Stop Solving" : "Auto Solve";

            newGameButton.Enabled = !isSolving;

            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool isSolving = _gameController.IsAutoSolving;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    _buttons[y, x].Enabled = !isSolving && _buttons[y, x].Text != "";
                }
            }
        }

    }
}