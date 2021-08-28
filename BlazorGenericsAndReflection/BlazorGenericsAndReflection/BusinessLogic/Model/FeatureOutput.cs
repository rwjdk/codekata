using BlazorGenericsAndReflection.BusinessLogic.Interface;

namespace BlazorGenericsAndReflection.BusinessLogic.Model
{
    public class FeatureOutput : IFeatureOutput
    {
        public int NumberValue { get; set; }
        public string StringValue { get; set; }

        public FeatureOutput(int numberValue, string stringValue)
        {
            NumberValue = numberValue;
            StringValue = stringValue;
        }
    }
}