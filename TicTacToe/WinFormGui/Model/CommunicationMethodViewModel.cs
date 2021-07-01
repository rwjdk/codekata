namespace WinFormGui.Model
{
    public class CommunicationMethodViewModel
    {
        public CommuncationMethod Method { get; }
        public string Description { get; }

        public CommunicationMethodViewModel(CommuncationMethod method, string description)
        {
            Method = method;
            Description = description;
        }
    }
}