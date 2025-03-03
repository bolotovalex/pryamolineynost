using System.Data;
using PryamolineynostWF.Services;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Controllers.Collimator
{
    public partial class MeasurementForm : Form
    {
        private MeasurementTable _dataSet;
        private MeasurementController _controller;
        public EventHandler cbSelectedPlaneChanged;
        public MeasurementForm(MeasurementTable dataSet, PryamolineynostWF.Enums.Plane? selectedPlane)
        {
            InitializeComponent();
            _dataSet = dataSet;
            _controller = new MeasurementController(this, dataSet, selectedPlane);
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = _dataSet.DataTable;

            cbPlaneUse.DataSource = Enum.GetValues(typeof(Plane))
                .Cast<Plane>()
                .Select(e => new { Value = e, Name = e.GetDescription() })
                .ToList();
            cbPlaneUse.DisplayMember = "Name";
            cbPlaneUse.ValueMember = "Value";
            cbPlaneUse.SelectedValue = selectedPlane;
            
            cbPlaneUse.SelectedValueChanged += cbPlaneUse_Change;
        }

        private void panel1_AutoSizeChanged(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void cbPlaneUse_Change(object sender, EventArgs e)
        {
            cbSelectedPlaneChanged?.Invoke(this, e);
        }

    }
}
