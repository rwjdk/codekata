using System.Diagnostics.CodeAnalysis;

namespace Logic.Model
{
    public class FrameResult
    {
        public int? Score { get; }
        public string Description { get; }

        public FrameResult(int? score, string description)
        {
            Score = score;
            Description = description;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{Description} (" + Score + ")";
        }
    }
}