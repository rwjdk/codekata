using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Model
{
    public class Game
    {
        public List<Frame> Frames { get; }
        public Frame Frame1 { get; }
        public Frame Frame2 { get; }
        public Frame Frame3 { get; }
        public Frame Frame4 { get; }
        public Frame Frame5 { get; }
        public Frame Frame6 { get; }
        public Frame Frame7 { get; }
        public Frame Frame8 { get; }
        public Frame Frame9 { get; }
        public Frame Frame10 { get; }
        public Frame Frame10Bonus1 { get; }
        public Frame Frame10Bonus2 { get; }

        public int CurrentFrameNumber { get; private set; }

        public Game()
        {
            Frame10Bonus2 = new Frame(12, null, null);
            Frame10Bonus1 = new Frame(11, Frame10Bonus2, null);
            Frame10 = new Frame(10, Frame10Bonus1, Frame10Bonus2);
            Frame9 = new Frame(9, Frame10, Frame10Bonus1);
            Frame8 = new Frame(8, Frame9, Frame10);
            Frame7 = new Frame(7, Frame8, Frame9);
            Frame6 = new Frame(6, Frame7, Frame8);
            Frame5 = new Frame(5, Frame6, Frame7);
            Frame4 = new Frame(4, Frame5, Frame6);
            Frame3 = new Frame(3, Frame4, Frame5);
            Frame2 = new Frame(2, Frame3, Frame4);
            Frame1 = new Frame(1, Frame2, Frame3);
            Frames = new List<Frame>
            {
                Frame1,
                Frame2,
                Frame3,
                Frame4,
                Frame5,
                Frame6,
                Frame7,
                Frame8,
                Frame9,
                Frame10,
                Frame10Bonus1,
                Frame10Bonus2
            };
            CurrentFrameNumber = 1;
        }

        public GameNextAction RegisterShot(ShotResult shotResult)
        {
            var shotResultAsNumber = Convert.ToInt32(shotResult);
            if (shotResultAsNumber < 0 || shotResultAsNumber > 10)
            {
                throw new InvalidOperationException("Shot result need to be between 0 and 10");
            }

            var frame = Frames[CurrentFrameNumber - 1];

            var score = frame.GetFrameScore().Score;
            if (score != null && score.Value + frame.ConvertToScore(shotResult) > 10)
            {
                throw new InvalidOperationException("Shot 2 added to Shot 1 can never exceed 10");
            }

            frame.RegisterShot(shotResult);
            if (!frame.IsFrameOver)
            {
                return GameNextAction.ContinueShooting;
            }

            if (!Frames.TrueForAll(x => x.IsFrameOver))
            {
                //Not all frames are over. Continue playing
                CurrentFrameNumber++;
                return GameNextAction.ContinueShooting;
            }

            //All frames are over. Game ended
            return GameNextAction.GameOver;
        }

        public int GetOverallScore()
        {
            int result = 0;
            var regularFrames = Frames.Where(x=> !x.IsBonusFrame);
            foreach (var frame in regularFrames)
            {
                var frameResult = frame.GetFrameScore();
                if (frameResult.Score.HasValue)
                {
                    result += frameResult.Score.Value;
                }
            }

            return result;
        }
    }
}