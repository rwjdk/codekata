using System;
using System.Text;
using System.Threading;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;
using Tennis.Model;

namespace Tennis.Control
{
    public class ConsoleGuiController : IGuiController
    {
        private readonly INumberOfSetsController _numberOfSetsController;
        private readonly IAutomationController _automationController;
        private readonly IGameScoreFormatter _gameScoreFormatter;
        private GameMode _gameMode;

        public ConsoleGuiController(INumberOfSetsController numberOfSetsController, IAutomationController automationController, IGameScoreFormatter gameScoreFormatter)
        {
            _numberOfSetsController = numberOfSetsController;
            _automationController = automationController;
            _gameScoreFormatter = gameScoreFormatter;
            _gameMode = GameMode.UserInput;
        }

        public void PrintMatchStatus(IMatch match)
        {
            Console.Clear();
            StringBuilder result = new StringBuilder();

            //Set overview
            PrintHeader(match, result);
            PrintLine(match, result);
            PrintCurrentServe(match, result, Player.Player1);
            result.Append("Player 1: ");
            OuputPlayerScore(match, result, Player.Player1);

            PrintSplitter(match, result);

            PrintCurrentServe(match, result, Player.Player2);
            result.Append("Player 2: ");
            OuputPlayerScore(match, result, Player.Player2);

            PrintLine(match, result);

            Console.Write(result.ToString());
        }

        public void DisplayFinalResult(IMatch match)
        {
            switch (match.Winner)
            {
                case Player.Player1:
                    Console.WriteLine("Player 1 won the match");
                    break;
                case Player.Player2:
                    Console.WriteLine("Player 2 won the match");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.ReadKey();
        }

        public INumberOfSetsUserInput AskForNumberOfSets()
        {
            Console.Write($"How many sets? ({GetValidNumberOfSetsAsString()}): ");
            return new ConsoleNumberOfSetsUserInput(_numberOfSetsController, Console.ReadLine());
        }

        public void DisplayInvalidNumberOfSets(INumberOfSetsUserInput userInput)
        {
            Console.Clear();
            Console.WriteLine($"'{userInput.Input}' is not a valid input for number of sets. Needs to be on of the following values: {GetValidNumberOfSetsAsString()}");
        }

        private IMatchStatusUserInput AskForWhoWonNextGame()
        {
            Console.Write("Enter \"1\" if player 1 or \"2\" if player 2 won this point (or \"EXIT\" to quit): ");
            return new ConsoleMatchStatusUserInput(Console.ReadLine());
        }

        public void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please try again");
        }

        private string GetValidNumberOfSetsAsString()
        {
            var validNumberOfSetsAsString = string.Join(", ", _numberOfSetsController.ValidNumberOfSets);
            return validNumberOfSetsAsString;
        }

        private void PrintCurrentServe(IMatch match, StringBuilder result, Player player)
        {
            result.Append(match.CurrentServe == player ? "* " : "  ");
        }

        private void PrintHeader(IMatch match, StringBuilder result)
        {
            result.Append(String.Empty.PadLeft(25, ' '));
            for (int i = 1; i <= match.Sets.Count; i++)
            {
                if (match.CurrentSetNumber == i)
                {
                    result.Append(i + "*  ");
                }
                else
                {
                    result.Append(i + "   ");
                }
            }
            result.Append(Environment.NewLine);
        }

        private void PrintSplitter(IMatch match, StringBuilder result)
        {
            result.Append(string.Empty.PadLeft(23, '-'));
            for (int i = 1; i <= match.Sets.Count; i++)
            {
                result.Append("|---");
            }
            result.Append("|" + Environment.NewLine);
        }

        private void PrintLine(IMatch match, StringBuilder result)
        {
            result.AppendLine(string.Empty.PadLeft(23 + 4 * match.Sets.Count, '-'));
        }

        private void OuputPlayerScore(IMatch match, StringBuilder result, Player player)
        {
            var gameScore = match.CurrentGame.GetGameScore();
            result.Append(FormatPoint(gameScore.GetScoreForPlayer(player)));
            for (int i = 1; i <= match.Sets.Count; i++)
            {
                result.Append("| " + match.Sets[i - 1].GetWonGamesForPlayer(player) + " ");
            }
            result.Append("|" + Environment.NewLine);
        }

        private string FormatPoint(GameScoreEnum? gameScore)
        {
            var result = _gameScoreFormatter.FormatPoint(gameScore);
            return result.PadLeft(10, ' ') + " ";
        }

        public Player? AskForWinnerOfNextGame()
        {
            switch (_gameMode)
            {
                case GameMode.UserInput:
                    var userInput = AskForWhoWonNextGame();
                    switch (userInput.Input)
                    {
                        case MatchStatusUserInput.Player1:
                            return Player.Player1;
                        case MatchStatusUserInput.Player2:
                            return Player.Player2;
                        case MatchStatusUserInput.Auto:
                            _gameMode = GameMode.Auto;
                            return null;
                        case MatchStatusUserInput.Exit:
                            ExitRequested?.Invoke();
                            return null;
                        case MatchStatusUserInput.InvalidInput:
                            DisplayInvalidInputMessage();
                            return null;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case GameMode.Auto:
                    var randomPlayer = _automationController.GetRandomPlayer();
                    Thread.Sleep(10);
                    return randomPlayer;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public event Action ExitRequested;
    }
}