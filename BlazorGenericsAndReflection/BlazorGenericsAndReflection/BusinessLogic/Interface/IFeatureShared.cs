namespace BlazorGenericsAndReflection.BusinessLogic.Interface
{
    public interface IFeatureShared<out T> where T: IFeatureOutput
    {
        string Name { get; }
        T Output { get; }
        void ActionOnButtonClick();

    }
}