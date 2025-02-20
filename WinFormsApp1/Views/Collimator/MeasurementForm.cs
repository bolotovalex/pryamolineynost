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
        private DataSet _dataSet;
        private MeasurementController _controller;
        public MeasurementForm(DataSet dataSet)
        {
            InitializeComponent();
            _dataSet = dataSet;
            _controller = new MeasurementController(dataSet, this );
        }

        private void panel1_AutoSizeChanged(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
