using System;
using System.Drawing;
using System.Windows.Forms;
using Communication.File.Control;
using Communication.SignalR.Control;
using Logic.Controller;
using Logic.Interface;
using Logic.Model;
using WinFormGui.Control;
using WinFormGui.Model;

namespace WinFormGui.View
{
    public partial class FormMain : Form
    {
        private CommuncationMethod defaultCommunicationMethod = CommuncationMethod.File;
        private IGameController _gameController;
        private readonly CommunicationMethodController _communicationMethodController;
        private readonly IStartingPlayerController _startingPlayerController;
        private readonly IGameIdGenerator _gameIdGenerator;

        public FormMain()
        {
            InitializeComponent();
            SetHostAndJoinElementsEnabled(true);
            SetGameModeVisible(false);
            _communicationMethodController = new CommunicationMethodController();
            _startingPlayerController = new StartingPlayerController();
            _gameIdGenerator = new GameIdGenerator();

            SetupCommunicationMethods(defaultCommunicationMethod);
        }

        private void InitializeCommunicationMethod(CommuncationMethod communcationMethod)
        {
            IGameStateController gameStateController;
            IWaitForOpponentController waitForOpponentController;
            switch (communcationMethod)
            {
                case CommuncationMethod.File:
                    var fileBasedController = new FileBasedController();
                    gameStateController = new FileBasedGameStateController(fileBasedController);
                    waitForOpponentController = new FileBasedWaitForOpponentController(fileBasedController);
                    break;
                case CommuncationMethod.SignalR:
                    var signalRClientController = new SignalRController();
                    gameStateController = new SignalRGameStateController(signalRClientController);
                    waitForOpponentController = new SignalRWaitForOpponentController(signalRClientController);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _gameController = new GameController(_gameIdGenerator, _startingPlayerController, gameStateController, waitForOpponentController);
            _gameController.WhoYouAreIdentified += OnWhoYouAreIdentified;
            _gameController.NextPlayersTurn += OnNextPlayersTurn;
            _gameController.GameEnded += OnGameEnded;
        }

        private void SetupCommunicationMethods(CommuncationMethod @default)
        {
            comboBoxCommunicationChannel.DataSource = _communicationMethodController.GetAvailableCommunicationMethods();
            comboBoxCommunicationChannel.ValueMember = nameof(CommunicationMethodViewModel.Method);
            comboBoxCommunicationChannel.DisplayMember = nameof(CommunicationMethodViewModel.Description);
            comboBoxCommunicationChannel.SelectedValue = @default;
        }

        private void OnWhoYouAreIdentified(PlayerViewModel me)
        {
            labelWhoAreYou.Text = $@"(You are: {me.Symbol})";
        }

        private void OnGameEnded(GameEndedEventArgs obj)
        {
            if (InvokeRequired)
            {
                labelWhosTurnIsIt.Invoke(new MethodInvoker(() =>
                {
                    labelWhosTurnIsIt.Text = $@"{obj.Result}";
                    RefreshBoard(obj.FinalVisualBoard);
                    tableLayoutPanel.Enabled = false;
                }));
            }
            else
            {
                labelWhosTurnIsIt.Text = $@"{obj.Result}";
                RefreshBoard(obj.FinalVisualBoard);
                tableLayoutPanel.Enabled = false;
            }
        }

        private void OnNextPlayersTurn(NextPlayersTurnEventArgs obj)
        {
            if (InvokeRequired)
            {
                labelWhosTurnIsIt.Invoke(new MethodInvoker(() =>
                {
                    labelWhosTurnIsIt.Text = $@"{obj.NextPlayer.Symbol} Turn";
                    RefreshBoard(obj.CurrentVisualBoard);
                }));
            }
            else
            {
                labelWhosTurnIsIt.Text = $@"{obj.NextPlayer.Symbol} Turn";
                RefreshBoard(obj.CurrentVisualBoard);
            }
        }

        private void RefreshBoard(string[,] board)
        {
            tableLayoutPanel.Enabled = _gameController.IsItMyTurn();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    var button = (Button) tableLayoutPanel.GetControlFromPosition(column, row);
                    button.Text = board[row, column];
                    if (!string.IsNullOrWhiteSpace(button.Text))
                    {
                        button.Enabled = false;
                    }
                }
            }
        }

        private void buttonHost_Click(object sender, EventArgs e)
        {
            InitializeCommunicationMethod((CommuncationMethod)comboBoxCommunicationChannel.SelectedValue);
            var gameId = _gameController.HostGame();
            SetGameId(gameId);
            SetupGame(@"Game started. (Tell game id to your opponent)");
        }

        private void SetupGame(string statusText)
        {
            SetHostAndJoinElementsEnabled(false);
            SetGameModeVisible(true);
            labelStatus.ForeColor = DefaultForeColor;
            labelStatus.Text = statusText;
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            var gameId = GetGameId();
            try
            {
                InitializeCommunicationMethod((CommuncationMethod)comboBoxCommunicationChannel.SelectedValue);
                _gameController.JoinGame(gameId);
                SetupGame(@"Game joined. Good luck!");
            }
            catch (NullReferenceException exception)
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = Text = exception.Message;
            }
        }

        private void SetGameId(int gameId)
        {
            numericUpDownGameId.Value = gameId;
        }

        private void SetHostAndJoinElementsEnabled(bool enabled)
        {
            numericUpDownGameId.Enabled = enabled;
            buttonHost.Enabled = enabled;
            buttonJoin.Enabled = enabled;
            comboBoxCommunicationChannel.Enabled = enabled;
        }

        private void SetGameModeVisible(bool visible)
        {
            labelWhoAreYou.Visible = visible;
            labelWhosTurnIsIt.Visible = visible;
            tableLayoutPanel.Visible = visible;
        }

        private int GetGameId()
        {
            return Convert.ToInt32(numericUpDownGameId.Value);
        }

        private void ClickCell(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var column = tableLayoutPanel.GetColumn(button);
            var row = tableLayoutPanel.GetRow(button);
            _gameController.MakeMove(row, column);
            tableLayoutPanel.Enabled = false;
        }
    }
}
