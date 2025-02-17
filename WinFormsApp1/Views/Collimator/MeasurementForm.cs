using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryamolineynostWF.Controllers.Collimator
{
    public partial class MeasurementForm : Form
    {
        public MeasurementForm()
        {
            InitializeComponent();
        }

        private void panel1_AutoSizeChanged(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }
    }
}
