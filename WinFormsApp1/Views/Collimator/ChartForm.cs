using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryamolineynostWF.Views.Collimator
{
    public partial class ChartForm: Form
    {
        public PlotView PlotView => plotView1;
        public ChartForm()
        {
            InitializeComponent();
        }
    }
}
