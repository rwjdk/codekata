using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BattleShip.Model;

namespace BattleShip
{
    class Program
    {
        static void Main()
        {
            Battle battle = new Battle();
            
            DrawBattleFields(battle);

            var opponent = battle.Player2Board;
            Console.WriteLine("It is now player 1's turn");

            var lastPlayer1HitResult = new CoordinateResult(null, null, CoordinateResultType.Miss);
            var lastPlayer2HitResult = new CoordinateResult(null, null, CoordinateResultType.Miss);
            while (true)
            {
                string input;
                if (opponent == battle.Player1Board)
                {
                    input = GetInput(lastPlayer2HitResult, opponent);
                    //input = Console.ReadLine().ToUpperInvariant();
                }
                else
                {
                    input = GetInput(lastPlayer1HitResult, opponent);
                    //input = Console.ReadLine().ToUpperInvariant();
                }
                if (input.Length == 2 || input.Length == 3)
                {
                    var xInput = input[0];
                    int yInput;
                    if (input.Length == 2)
                    {
                        yInput = Convert.ToInt32(input[1].ToString());
                    }
                    else
                    {
                        yInput = Convert.ToInt32(input[1].ToString() + input[2].ToString());
                    }

                    int x = XValueConverter.GetNumber(xInput);
                    int y = yInput;

                    var result = opponent.GetResultFromCoordinate(x, y);
                    switch (result.Type)
                    {
                        case CoordinateResultType.Hit:
                            opponent.Hits.Add(new Coordinate(x, y));
                            result.Section.Damaged = true;
                            if (opponent == battle.Player2Board)
                            {
                                lastPlayer1HitResult = result;
                            }
                            else
                            {
                                lastPlayer2HitResult = result;
                            }
                            DrawBattleFields(battle);
                            Console.Write(input + " is a Hit!");
                            if (result.Ship.IsSunk())
                            {
                                Console.Write(" - You sunk my " + result.Ship.Name);
                            }
                            break;
                        case CoordinateResultType.Miss:
                            opponent.Misses.Add(new Coordinate(x, y));
                            DrawBattleFields(battle);
                            Console.Write(input + " is a Miss!");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                if (opponent.AllShipsSunk())
                {
                    DrawBattleFields(battle, true);
                    if (opponent == battle.Player1Board)
                    {
                        Console.WriteLine("Player 2 Won!!!");
                    }
                    else
                    {
                        Console.WriteLine("Player 1 Won!!!");
                    }
                    break;
                }

                if (opponent == battle.Player1Board)
                {
                    opponent = battle.Player2Board;
                    Console.WriteLine(" - It is now player 1's turn");
                }
                else
                {
                    opponent = battle.Player1Board;
                    Console.WriteLine(" - It is now player 2's turn");
                }
            }

            Console.ReadKey();
        }

        private static string GetInput(CoordinateResult lastPlayerHitResult, Board opponent)
        {
            string input;
            //Console.ReadKey();
            //AI -Move
            int x;
            int y;
            if (lastPlayerHitResult.Type == CoordinateResultType.Miss || lastPlayerHitResult.Ship.IsSunk())
            {
                var random = new Random(DateTime.Now.Millisecond);
                x = random.Next(1, 11);
                y = random.Next(1, 11);
                while (opponent.HasMiss(x, y) || opponent.HasHit(x, y))
                {
                    random = new Random(DateTime.Now.Millisecond);
                    x = random.Next(1, 11);
                    y = random.Next(1, 11);
                }
            }
            else
            {
                var random = new Random(DateTime.Now.Millisecond);
                var direction = (AiDirection) random.Next(1, 5);
                switch (direction)
                {
                    case AiDirection.Left:
                        x = lastPlayerHitResult.Section.X - 1;
                        y = lastPlayerHitResult.Section.Y;
                        break;
                    case AiDirection.Right:
                        x = lastPlayerHitResult.Section.X + 1;
                        y = lastPlayerHitResult.Section.Y;
                        break;
                    case AiDirection.Up:
                        x = lastPlayerHitResult.Section.X;
                        y = lastPlayerHitResult.
                            
                             Section.Y - 1;
                        break;
                    case AiDirection.Down:
                        x = lastPlayerHitResult.Section.X;
                        y = lastPlayerHitResult.Section.Y + 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                var directionsTried = new List<AiDirection>();
                while (x < 1 || x > 10 || y < 1 || y > 10 || opponent.HasMiss(x, y) || opponent.HasHit(x, y))
                {
                    if (directionsTried.Count == 4)
                    {
                        lastPlayerHitResult = new CoordinateResult(null, null, CoordinateResultType.Miss);
                        return GetInput(lastPlayerHitResult, opponent);
                    }
                    random = new Random(DateTime.Now.Millisecond);
                    direction = (AiDirection) random.Next(1, 5);
                    if (!directionsTried.Contains(direction))
                    {
                        directionsTried.Add(direction);
                    }
                    switch (direction)
                    {
                        case AiDirection.Left:
                            x = lastPlayerHitResult.Section.X - 1;
                            y = lastPlayerHitResult.Section.Y;
                            break;
                        case AiDirection.Right:
                            x = lastPlayerHitResult.Section.X + 1;
                            y = lastPlayerHitResult.Section.Y;
                            break;
                        case AiDirection.Up:
                            x = lastPlayerHitResult.Section.X;
                            y = lastPlayerHitResult.Section.Y - 1;
                            break;
                        case AiDirection.Down:
                            x = lastPlayerHitResult.Section.X;
                            y = lastPlayerHitResult.Section.Y + 1;
                            break;
                    }
                }
            }
            var letter = XValueConverter.GetLetter(x);
            input = letter.ToString(CultureInfo.InvariantCulture) + y;
            return input;
        }

        private static void DrawBattleFields(Battle battle, bool showEndResult = false)
        {
            Console.Clear();
            var player1Board = battle.Player1Board;
            var player2Board = battle.Player2Board;

            //Console.WriteLine("Player 1");
            DrawBoard(player1Board, showEndResult);
            Console.WriteLine();
            //Console.WriteLine("Player 2");
            DrawBoard(player2Board, showEndResult);
        }

        private static void DrawBoard(Board board, bool showEndResult = false)
        {
            Console.Write(" ");
            for (int i = 0; i < board.Height; i++)
            {
                Console.Write(" " + (i + 1).ToString().PadLeft(2, '0'));
            }
            Console.WriteLine();
            for (int i = 0; i < board.Width; i++)
            {
                var letter = XValueConverter.GetLetter(i + 1);
                Console.Write(letter);

                for (int j = 0; j < board.Height; j++)
                {
                    int x = i + 1;
                    int y = j + 1;
                    var result = board.GetResultFromCoordinate(x, y);
                    string symbol;
                    switch (result.Type)
                    {
                        case CoordinateResultType.Hit:
                            if (result.Section.Damaged)
                            {
                                symbol = "[X]";
                            }
                            else
                            {
                                if (showEndResult)
                                {
                                    symbol = "[" + result.Ship.Symbol + "]";
                                }
                                else
                                {
                                    symbol = "[ ]";
                                }

                            }
                            break;
                        case CoordinateResultType.Miss:
                            if (board.HasMiss(x, y))
                            {
                                symbol = "[~]";
                            }
                            else
                            {
                                symbol = "[ ]";
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
    }

    internal class XValueConverter
    {
        public static char GetLetter(int value)
        {
            return (char)(64 + value);
        }

        public static int GetNumber(char value)
        {
            return value - 64;
        }
    }
}
