using System;
using System.IO;
using GameOfLife.Logic.Model;

namespace GameOfLife.Logic.Control
{
    public class SeedReader
    {
        public string[] ReadPredefinedSeed(PredefinedSeed seed)
        {
            switch (seed)
            {
                case PredefinedSeed.Block:
                    return ReadSeed("Seeds\\Block.txt");
                case PredefinedSeed.Blinker:
                    return ReadSeed("Seeds\\Blinker.txt");
                case PredefinedSeed.Glider:
                    return ReadSeed("Seeds\\Glider.txt");
                case PredefinedSeed.SmallExploder:
                    return ReadSeed("Seeds\\SmallExploder.txt");
                case PredefinedSeed.Exploder:
                    return ReadSeed("Seeds\\Exploder.txt");
                case PredefinedSeed.GosperGliderGun:
                    return ReadSeed("Seeds\\GosperGliderGun.txt");
                default:
                    throw new ArgumentOutOfRangeException(nameof(seed), seed, null);
            }
        }

        public string[] ReadSeed(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}