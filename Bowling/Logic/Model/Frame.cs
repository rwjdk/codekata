using System;
using System.Diagnostics.CodeAnalysis;

namespace Logic.Model
{
    public class Frame
    {
        public int Number { get; }
        private Frame FramePlus1 { get; }
        private Frame FramePlus2 { get; }
        private int CurrentShot { get; set; }
        private ShotResult Shot1 { get; set; }
        private ShotResult Shot2 { get; set; }
        private bool IsLastFrame => Number == 10;
        public bool IsStrike => Shot1 == ShotResult.Score10;
        public bool IsSpare => ConvertToScore(Shot1) + ConvertToScore(Shot2) == 10;
        public bool IsBonusFrame => Number > 10;
        public bool IsFrameOver { get; private set; }

        internal Frame(int number, Frame framePlus1, Frame framePlus2)
        {
            if (number < 1 || number > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Framenumber should be between 1 and 12");
            }
            Number = number;
            FramePlus1 = framePlus1;
            FramePlus2 = framePlus2;
            Shot1 = ShotResult.NotTaken;
            Shot2 = ShotResult.NotTaken;
            CurrentShot = 0;
        }

        internal void RegisterShot(ShotResult result)
        {
            CurrentShot++;
            switch (CurrentShot)
            {
                case 1:
                    RegisterShot1(result);
                    break;
                case 2:
                    RegisterShot2(result);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid shot. There can never be {CurrentShot} shots in a frame");
            }
        }

        private void RegisterShot1(ShotResult result)
        {
            Shot1 = result;
            if (IsStrike)
            {
                //Since shot is a strike we do not need shot 2 and the frame is over
                Shot2 = ShotResult.NotNeeded;
                IsFrameOver = true;
            }
        }

        private void RegisterShot2(ShotResult result)
        {
            Shot2 = result;

            if (IsLastFrame)
            {
                if (IsSpare)
                {
                    //Last frame was a a spare so we need one extra shot in a single bonus-frame
                    FramePlus1.Shot2 = ShotResult.NotNeeded; //Shot 2 in Bonus Frame 1 is not needed
                    FramePlus2.IsFrameOver = true; //Bonus Frame 2 is not needed
                }
                else
                {
                    //Last frame with no special result so none of the bonus frames are needed
                    FramePlus1.IsFrameOver = true;
                    FramePlus2.IsFrameOver = true;
                }
            }
            else if (IsBonusFrame && IsSpare)
            {
                //We got a strike in last frame and now a spare in the first Bonus Frame, so Bonus frame 2 is not needed since you do not get bonus shot for spares in a bonus frame
                FramePlus1.IsFrameOver = true;
            }

            IsFrameOver = true; //No matter what the frame is over since this was the second shot
        }

        public FrameResult GetFrameScore()
        {
            if (IsStrike)
            {
                return GetFrameScoreForStrike();
            }

            if (IsSpare)
            {
                return GetFrameScoreForSpare();
            }

            //No shots taken
            if (Shot1 == ShotResult.NotTaken && Shot2 == ShotResult.NotTaken) 
            {
                return new FrameResult(null, "[ ][ ]");
            }

            //Only first shot taken yet
            var shot1Score = ConvertToScore(Shot1);
            if (Shot2 == ShotResult.NotTaken) 
            {
                return new FrameResult(shot1Score, $"[{shot1Score}][ ]");
            }

            //Both shots was taken
            var shot2Score = ConvertToScore(Shot2);
            return new FrameResult(shot1Score + shot2Score, $"[{shot1Score}][{shot2Score}]");
        }

        private FrameResult GetFrameScoreForSpare()
        {
            var shot1Score = ConvertToScore(Shot1);
            var description = $"[{shot1Score}][/]";
            //Spare in normal frame are dependant on one more frame
            if (FramePlus1.Shot1 != ShotResult.NotTaken)
            {
                var shot2Score = ConvertToScore(Shot2);
                int? score = shot1Score + shot2Score + ConvertToScore(FramePlus1.Shot1);
                return new FrameResult(score, description);
            }

            //FramePlus1's first shot have not been taken yet so can't calculate
            return new FrameResult(null, description);
        }

        private FrameResult GetFrameScoreForStrike()
        {
            //Strike in normal frame are dependant on one or two frames dependant of their Results
            var description = "[X][-]";

            if (!FramePlus1.IsFrameOver)
            {
                //FramePlus1 is not over so can't calculate
                return new FrameResult(null, description);
            }

            int? score;
            if (FramePlus1.IsStrike)
            {
                //Shot 1 of framePlus2 is needed for the result
                if (FramePlus2.Shot1 != ShotResult.NotTaken)
                {
                    score = ConvertToScore(Shot1) + ConvertToScore(FramePlus1.Shot1) + ConvertToScore(FramePlus2.Shot1);
                    return new FrameResult(score, description);
                }

                //FramePlus2 is not over so can't calculate
                return new FrameResult(null, description);
            }

            //FramePlus1 was over but was not a strike so we can calculate score based on current and Plus1
            score = ConvertToScore(Shot1) + ConvertToScore(Shot2) + ConvertToScore(FramePlus1.Shot1) + ConvertToScore(FramePlus1.Shot2);
            return new FrameResult(score, description);
        }

        internal int ConvertToScore(ShotResult shotResult)
        {
            switch (shotResult)
            {
                case ShotResult.NotTaken:
                case ShotResult.NotNeeded:
                    return 0;
                default:
                    return Convert.ToInt32(shotResult);
            }
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Frame {Number} - [{Shot1}] [{Shot2}]";
        }
    }
}