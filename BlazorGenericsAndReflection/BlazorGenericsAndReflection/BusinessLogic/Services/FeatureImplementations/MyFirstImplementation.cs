using System;
using BlazorGenericsAndReflection.BusinessLogic.Interface;
using BlazorGenericsAndReflection.BusinessLogic.Model;

namespace BlazorGenericsAndReflection.BusinessLogic.Services.FeatureImplementations
{
    public class MyFirstImplementation : IFeature
    {
        public string Name => "First";
        public IFeatureOutput Output { get; }
        public void ActionOnButtonClick()
        {
            Console.WriteLine("MyFirstImplementation Click");
        }

        public MyFirstImplementation()
        {
            Output = new FeatureOutput(42, "Hello");
        }
    }
}