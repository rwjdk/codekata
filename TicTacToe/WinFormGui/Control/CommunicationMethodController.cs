using System.Collections.Generic;
using WinFormGui.Model;

namespace WinFormGui.Control
{
    public class CommunicationMethodController
    {
        public List<CommunicationMethodViewModel> GetAvailableCommunicationMethods()
        {
            return new List<CommunicationMethodViewModel>
            {
                new CommunicationMethodViewModel(CommuncationMethod.File, "File"),
                new CommunicationMethodViewModel(CommuncationMethod.SignalR, "SignalR")
            };
        }
    }
}