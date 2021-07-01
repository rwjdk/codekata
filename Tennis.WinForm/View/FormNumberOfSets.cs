using System;
using System.Windows.Forms;

namespace Tennis.WinForm.View
{
    public partial class FormNumberOfSets : Form
    {
        public FormNumberOfSets()
        {
            InitializeComponent();
        }

        public int NumberOfSets { get; private set; }

        private void button1Set_Click(object sender, EventArgs e)
        {
            SetNumberOfSetsAndClose(1);
        }
        
        private void button3Set_Click(object sender, EventArgs e)
        {
            SetNumberOfSetsAndClose(3);
        }

        private void button5Set_Click(object sender, EventArgs e)
        {
            SetNumberOfSetsAndClose(5);
        }

        private void SetNumberOfSetsAndClose(int numberOfSets)
        {
            NumberOfSets = numberOfSets;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort; 
            Close();
        }
    }
}
