using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.WinForm.View
{
    public partial class FormMain : Form
    {
        private readonly IAppController _appController;
        private readonly IGuiController _guiController;
        private readonly IGameScoreFormatter _gameScoreFormatter;
        private readonly IAutomationController _automationController;

        public FormMain()
        {
            InitializeComponent();
            _appController = DependencyInjection.Resolve<IAppController>();
            _guiController = DependencyInjection.Resolve<IGuiController>();
            _gameScoreFormatter = DependencyInjection.Resolve<IGameScoreFormatter>();
            _automationController = DependencyInjection.Resolve<IAutomationController>();
            _appController.GameStatusChanged += _appController_GameStatusChanged;
            _appController.MatchIsOver += _appController_MatchIsOver;
        }

        private void _appController_MatchIsOver(IMatch obj)
        {
            _guiController.DisplayFinalResult(obj);
        }

        private void _appController_GameStatusChanged(IMatch match)
        {
            ShowHideSets(match);
            SetActivePlayer(match);
            SetActiveSet(match);
            SetValues(match);

            if (match.Winner.HasValue)
            {
                buttonAddGamePlayer1.Enabled = false;
                buttonAddGamePlayer2.Enabled = false;
                buttonAuto.Enabled = false;
            }
        }

        private void SetValues(IMatch match)
        {
            var gameScore = match.CurrentGame.GetGameScore();
            labelPlayer1.Text = $@"Player 1 ({_gameScoreFormatter.FormatPoint(gameScore.GetScoreForPlayer(Player.Player1))})";
            labelPlayer2.Text = $@"Player 2 ({_gameScoreFormatter.FormatPoint(gameScore.GetScoreForPlayer(Player.Player2))})";

            foreach (var set in match.Sets)
            {
                switch (set.SetNumber)
                {
                    case 1:
                        labelSet1Player1.Text = set.GetWonGamesForPlayer(Player.Player1).ToString();
                        labelSet1Player2.Text = set.GetWonGamesForPlayer(Player.Player2).ToString();
                        break;
                    case 2:
                        labelSet2Player1.Text = set.GetWonGamesForPlayer(Player.Player1).ToString();
                        labelSet2Player2.Text = set.GetWonGamesForPlayer(Player.Player2).ToString();
                        break;
                    case 3:
                        labelSet3Player1.Text = set.GetWonGamesForPlayer(Player.Player1).ToString();
                        labelSet3Player2.Text = set.GetWonGamesForPlayer(Player.Player2).ToString();
                        break;
                    case 4:
                        labelSet4Player1.Text = set.GetWonGamesForPlayer(Player.Player1).ToString();
                        labelSet4Player2.Text = set.GetWonGamesForPlayer(Player.Player2).ToString();
                        break;
                    case 5:
                        labelSet5Player1.Text = set.GetWonGamesForPlayer(Player.Player1).ToString();
                        labelSet5Player2.Text = set.GetWonGamesForPlayer(Player.Player2).ToString();
                        break;
                }
                
            }
        }

        private void SetActiveSet(IMatch match)
        {
            labelSet1.ForeColor = DefaultForeColor;
            labelSet2.ForeColor = DefaultForeColor;
            labelSet3.ForeColor = DefaultForeColor;
            labelSet4.ForeColor = DefaultForeColor;
            labelSet5.ForeColor = DefaultForeColor;
            switch (match.CurrentSetNumber)
            {
                    case 1:
                        labelSet1.ForeColor = Color.Red;
                        break;
                    case 2:
                        labelSet2.ForeColor = Color.Red;
                        break;
                    case 3:
                        labelSet3.ForeColor = Color.Red;
                        break;
                    case 4:
                        labelSet4.ForeColor = Color.Red;
                        break;
                    case 5:
                        labelSet5.ForeColor = Color.Red;
                        break;
            }
        }

        private void SetActivePlayer(IMatch obj)
        {
            if (obj.CurrentServe == Player.Player1)
            {
                labelPlayer1.ForeColor = Color.Red;
                labelPlayer2.ForeColor = DefaultForeColor;
            }
            else
            {
                labelPlayer1.ForeColor = DefaultForeColor;
                labelPlayer2.ForeColor = Color.Red;
            }
        }

        private void ShowHideSets(IMatch obj)
        {
            switch (obj.Sets.Count)
            {
                case 1:
                    ShowHideSet(GetSetLabels(5), false);
                    ShowHideSet(GetSetLabels(4), false);
                    ShowHideSet(GetSetLabels(3), false);
                    ShowHideSet(GetSetLabels(2), false);
                    ShowHideSet(GetSetLabels(1), true);
                    break;
                case 3:
                    ShowHideSet(GetSetLabels(5), false);
                    ShowHideSet(GetSetLabels(4), false);
                    ShowHideSet(GetSetLabels(3), true);
                    ShowHideSet(GetSetLabels(2), true);
                    ShowHideSet(GetSetLabels(1), true);
                    break;
                case 5:
                    ShowHideSet(GetSetLabels(5), true);
                    ShowHideSet(GetSetLabels(4), true);
                    ShowHideSet(GetSetLabels(3), true);
                    ShowHideSet(GetSetLabels(2), true);
                    ShowHideSet(GetSetLabels(1), true);
                    break;
            }
        }

        private void ShowHideSet(List<Label> setLabels, bool visible)
        {
            foreach (var label in setLabels)
            {
                label.Visible = visible;    
            }
        }

        private List<Label> GetSetLabels(int set)
        {
            switch (set)
            {
                case 1:
                    return new List<Label> { labelSet1, labelSet1Player1, labelSet1Player2};
                case 2:
                    return new List<Label> { labelSet2, labelSet2Player1, labelSet2Player2};
                case 3:
                    return new List<Label> { labelSet3, labelSet3Player1, labelSet3Player2};
                case 4:
                    return new List<Label> { labelSet4, labelSet4Player1, labelSet4Player2};
                case 5:
                    return new List<Label> { labelSet5, labelSet5Player1, labelSet5Player2};
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (_appController.IsNumberOfSetsNotDefined())
            {
                _appController.AskForNumberOfSets();
            }

            _appController.StartMatch();
        }

        private void buttonAddGamePlayer1_Click(object sender, EventArgs e)
        {
            _appController.SetWinnerOfNextGame(Player.Player1);
        }

        private void buttonAddGamePlayer2_Click(object sender, EventArgs e)
        {
            _appController.SetWinnerOfNextGame(Player.Player2);
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            while (_appController.HaveNotYetFoundItsWinner())
            {
                var randomPlayer = _automationController.GetRandomPlayer();
                _appController.SetWinnerOfNextGame(randomPlayer);
                Thread.Sleep(20);
                Refresh();
            }
        }
    }
}
