namespace BlazorGenericsAndReflection.BusinessLogic.Interface
{
    //public interface IFeature
    public interface IFeature<out T> where T: IFeatureOutput
    {
        string Name { get; }
        T Output { get; }
        void ActionOnButtonClick();

    }
}