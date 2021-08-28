namespace BlazorGenericsAndReflection.BusinessLogic.Interface
{
    public interface IFeature
    //public interface IFeature<out T> where T: IFeatureOutput
    {
        string Name { get; }
        IFeatureOutput Output { get; }
        void ActionOnButtonClick();

    }
}