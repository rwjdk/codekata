using System.Windows.Forms;
using Tennis.Logic.Interface;

namespace Tennis.WinForm.Control
{
    public class WinFormTerminationController : ITerminationController
    {
        public void TerminateApp()
        {
            Application.Exit();
        }
    }
}