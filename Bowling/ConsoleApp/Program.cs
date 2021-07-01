using System;
using System.Linq;
using Logic.Model;

namespace ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            var game = new Game();
            GameNextAction nextAction = GameNextAction.ContinueShooting;
            while (nextAction == GameNextAction.ContinueShooting)
            {
                DisplayGameStatus(game);
                Console.Write("Enter result of next shot: ");
                var result = Console.ReadLine();
                if (result?.ToUpperInvariant() == "X")
                {
                    result = "10";
                }
                if (int.TryParse(result, out int resultAsInteger))
                {
                    try
                    {
                        nextAction = game.RegisterShot((ShotResult)resultAsInteger);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine($"Invalid Input: {e.Message}. Press any key to try again");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. Press any key to try again");
                    Console.ReadKey();
                }
            }

            DisplayGameStatus(game);
            Console.WriteLine($"Game is over - Your final score was {game.GetOverallScore()}");
            Console.ReadKey();
        }

        private static void DisplayGameStatus(Game game)
        {
            Console.Clear();
            var normalFrames = game.Frames.Where(x => !x.IsBonusFrame).ToList();
            foreach (var frame in normalFrames)
            {
                Console.Write(frame.Number.ToString().PadRight(6, ' ') + " ");
            }
            Console.WriteLine();
            foreach (var frame in normalFrames)
            {
                Console.Write(frame.GetFrameScore().Description + " ");
            }
            Console.WriteLine();
            foreach (var frame in normalFrames)
            {
                Console.Write(frame.GetFrameScore().Score.ToString().PadRight(6, ' ') + " ");
            }
            Console.WriteLine();
            switch (game.CurrentFrameNumber)
            {
                case 11:
                    Console.WriteLine($"Current Frame: Bonus 1 - Total: {game.GetOverallScore()}");
                    break;
                case 12:
                    Console.WriteLine($"Current Frame: Bonus 2 - Total: {game.GetOverallScore()}");
                    break;
                default:
                    Console.WriteLine($"Current Frame: {game.CurrentFrameNumber} - Total: {game.GetOverallScore()}");
                    break;
            }
            
        }
    }
}
