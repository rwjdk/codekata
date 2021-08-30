using System;
using BlazorGenericsAndReflection.BusinessLogic.Interface;

namespace BlazorGenericsAndReflection.BusinessLogic.Services
{
    public class SharedImplementation : IFeatureShared<IFeatureOutput>
    {
        private readonly Action _actionOnButtonClick;
        public string Name { get; }
        public IFeatureOutput Output { get; }
        public void ActionOnButtonClick()
        {
            _actionOnButtonClick.Invoke();
        }

        public SharedImplementation(string name, IFeatureOutput output, Action actionOnButtonClick)
        {
            _actionOnButtonClick = actionOnButtonClick;
            Name = name;
            Output = output;
        }

        public SharedImplementation()
        {
            //Empty
        }
    }
}