using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Controllers.Collimator
{
    
    public class MeasurementController
    {
        private MeasurementForm _view;
        private MeasurementTable _dataSet;
        private Enums.Plane? _selectedPlane;
        public MeasurementController(MeasurementTable dataSet, Enums.Plane? selectedPlane)
        {
            _dataSet = dataSet;
            _view = new MeasurementForm(dataSet, selectedPlane);
            _selectedPlane = selectedPlane;
            _view.cbSelectedPlaneChanged += ComboBox1_SelectedValueChange;
            _view.dataGridView1RowAdded += DataGridView1_RowAdded;
            _view.dataGridView1RowRemoved += DataGridView1_RowRemoved;
            _view.dataGridView1CellValueChanged += DataGridView1_CellValueChanged;
            _view.dataGridViewCellFormattingChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_RowAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dataSet.DataTable.Rows.Count)
            {
                _dataSet.AddRow();
            }
        }

        private void DataGridView1_RowRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //var dataGridView = sender as DataGridView;
            //if (dataGridView != null)
            //{
            //    for (int i = 0; i < e.RowCount; i++)
            //    {
            //        int rowIndex = e.RowIndex + i;
            //        if (rowIndex < _dataSet.DataTable.Rows.Count)
            //        {
            //            _dataSet.DataTable.Rows.RemoveAt(rowIndex);
            //        }
            //    }
            //}
        }

        public Enums.Plane? SelectedPlane
        {
            get => _selectedPlane;
            set 
            {
                _selectedPlane = value;
                _view.cbPlaneUse.SelectedValue = value;
            }
        }
        
        private void ComboBox1_SelectedValueChange(object? sender, EventArgs e)
        {
            if (_view.cbPlaneUse.SelectedValue is PryamolineynostWF.Enums.Plane selected)
            {
                _selectedPlane = selected;
            }
            //else
            //{
            //    _selectedPlane = null;
            //}
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = _view.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            _dataSet.UpdateRow(e.RowIndex, e.ColumnIndex, newValue);

        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != DBNull.Value && (Int32)e.Value == MeasurementTable.IntPlaceholder)
            {
                e.CellStyle.BackColor = Color.Red;
                e.Value = "";
                e.FormattingApplied = true;
            }
            else
            {
                e.CellStyle.BackColor = Color.White;
            }
        }

        public void ShowForm()
        {
            _view.Show();
        }
    }
}
