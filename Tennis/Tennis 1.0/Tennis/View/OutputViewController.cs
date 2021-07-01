using System;
using System.Text;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.View
{
    internal class OutputViewController
    {
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

        private static void PrintCurrentServe(IMatch match, StringBuilder result, Player player)
        {
            if (match.CurrentServe == player)
            {
                result.Append("* ");
            }
            else
            {
                result.Append("  ");
            }
        }

        public void PrintFinalResult(IMatch match)
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

        private void PrintHeader(IMatch match, StringBuilder result)
        {
            result.Append(string.Empty.PadLeft(25, ' '));
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
            result.Append(String.Empty.PadLeft(23, '-'));
            for (int i = 1; i <= match.Sets.Count; i++)
            {
                result.Append("|---");
            }
            result.Append("|" + Environment.NewLine);
        }

        private void PrintLine(IMatch match, StringBuilder result)
        {
            result.AppendLine(String.Empty.PadLeft(23 + 4 * match.Sets.Count, '-'));
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
            string result;
            switch (gameScore)
            {
                case GameScoreEnum.Score0:
                    result = "0";
                    break;
                case GameScoreEnum.Score15:
                    result = "15";
                    break;
                case GameScoreEnum.Score30:
                    result = "30";
                    break;
                case GameScoreEnum.Score40:
                    result = "40";
                    break;
                case GameScoreEnum.Advantage:
                    result = "Advantage";
                    break;
                case GameScoreEnum.Deuce:
                    result = "Deuce";
                    break;
                case null:
                    result = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return result.PadLeft(10, ' ') + " ";
        }

        public void PrintInstructions()
        {
            Console.Write("Enter \"1\" if player 1 or \"2\" if player 2 won this point (or \"exit\" to quit): ");
        }

        public void PrintInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Try again");
        }

        public void PrintNumberOfSetSelection()
        {
            Console.Write("How many sets? (1, 3 or 5): ");
        }
    }
}