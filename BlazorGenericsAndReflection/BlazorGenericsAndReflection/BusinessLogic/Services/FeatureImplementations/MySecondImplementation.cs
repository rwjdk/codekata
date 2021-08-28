using System;
using BlazorGenericsAndReflection.BusinessLogic.Interface;
using BlazorGenericsAndReflection.BusinessLogic.Model;

namespace BlazorGenericsAndReflection.BusinessLogic.Services.FeatureImplementations
{
    public class MySecondImplementation : IFeature<IFeatureOutput>
    {
        public string Name => "Second";
        public IFeatureOutput Output { get; }
        public void ActionOnButtonClick()
        {
            Console.WriteLine("MySecondImplementation Click");
        }

        public MySecondImplementation()
        {
            Output = new FeatureOutput(999, "World");
        }
    }
}