using GameOfLife.Console.Control;
using GameOfLife.Logic.Control;
using GameOfLife.Logic.Extensions;
using GameOfLife.Logic.Model;

namespace GameOfLife.Console
{
    static class Program
    {
        static void Main()
        {
            var seedReader = new SeedReader();
            var consoleUniverseCreator = new UniverseCreator();
            var consoleUniverseVisualizer = new ConsoleUniverseVisualizer();

            var blockSeed = seedReader.ReadPredefinedSeed(PredefinedSeed.GosperGliderGun);
            var universe = consoleUniverseCreator.CreateConsoleUniverse(blockSeed);

            string input = string.Empty;
            while (input?.ToUpperInvariant() != "EXIT")
            {
                System.Console.Clear();
                consoleUniverseVisualizer.WriteUniverse(universe);
                universe = universe.Tick();
                input = System.Console.ReadLine();
            }
        }
    }
}
