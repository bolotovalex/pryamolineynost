using System.Data;
using PryamolineynostWF.Services;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Controllers.Collimator
{
    public partial class MeasurementForm : Form
    {
        private MeasurementTableModel _dataSet;
        private MeasurementController _controller;
        public EventHandler cbSelectedPlaneChanged;

        public DataGridViewCellEventHandler dataGridView1CellValueChanged;
        public DataGridViewRowsAddedEventHandler dataGridView1RowAdded;
        public DataGridViewRowsRemovedEventHandler dataGridView1RowRemoved;
        public DataGridViewCellFormattingEventHandler dataGridViewCellFormattingChanged;
        public DataGridViewCellValidatingEventHandler dataGridViewCellValidating;
        public DataGridViewCellCancelEventHandler DataGridView1CellBeginEdit;


        private BindingSource _bindingSource;
        private MeasurementTableModel _measurementTableModel;



        public MeasurementForm(MeasurementTableModel dataSet, PryamolineynostWF.Enums.Plane? selectedPlane)
        {
            
            InitializeComponent();
            _dataSet = dataSet;
            this.dataGridView1.AutoGenerateColumns = true;

            BindingTable();
            //this.dataGridView1.DataSource = _dataSet.DataTable;

            cbPlaneUse.DataSource = Enum.GetValues(typeof(Plane))
                .Cast<Plane>()
                .Select(e => new { Value = e, Name = e.GetDescription() })
                .ToList();
            cbPlaneUse.DisplayMember = "Name";
            cbPlaneUse.ValueMember = "Value";
            cbPlaneUse.SelectedValue = selectedPlane;

            cbPlaneUse.SelectedValueChanged += cbPlaneUse_Change;
        }

        private void BindingTable()
        {
            _bindingSource = new BindingSource();
            
            _measurementTableModel = new MeasurementTableModel("Горизонтальная поверхность");
            _measurementTableModel.Table.Add(new MeasurementRowModel(222, null, false));
            _bindingSource.DataSource = _measurementTableModel.Table;
            dataGridView1.DataSource = _bindingSource;
            
            //_bindingSource.ResetBindings(false); //Обновление
        }

        private void DataGridView1_CellValidated(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewCellValidating?.Invoke(this, e);
        }

        private void Panel1_AutoSizeChanged(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void cbPlaneUse_Change(object sender, EventArgs e)
        {
            cbSelectedPlaneChanged?.Invoke(this, e);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                var cell = dataGridView[e.ColumnIndex, e.RowIndex];
                if (cell.ReadOnly)
                {
                    cell.Selected = false;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1CellValueChanged.Invoke(this, e);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    var dataGridView = sender as DataGridView;
            //    if (dataGridView != null)
            //    {
            //        var cell = dataGridView[e.ColumnIndex, e.RowIndex];
            //        if (cell.ReadOnly)
            //        {
            //            cell.Selected = false;
            //        }
            //    }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var dataGridView = sender as DataGridView;
            //if (dataGridView != null)
            //{
            //    var cell = dataGridView[e.ColumnIndex, e.RowIndex];
            //    if (cell.ReadOnly)
            //    {
            //        cell.Selected = false;
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_dataSet.AddRow(0, 0, 0, 0, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_dataSet.Rows.Clear();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewCellFormattingChanged.Invoke(this, e);
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView1CellBeginEdit?.Invoke(this, e);
        }
    }
}
