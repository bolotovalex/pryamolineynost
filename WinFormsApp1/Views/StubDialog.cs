using System;
using System.Windows.Forms;

namespace PryamolineynostWF.Views
{
    public partial class StubDialog : Form
    {
        public StubDialog(string message)
        {
            InitializeComponent();
            messageLabel.Text = message;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
