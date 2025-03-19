using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Controllers.Collimator
{
    
    public class MeasurementTableController
    {
        private MeasurementTableForm _view;
        private MeasurementTableModel _model;
        private BindingSource _bindingSource;
        private CollimatorModel _dataSet;
        
        public MeasurementTableController(CollimatorModel dataSet)
        {
            _model = dataSet.MeasurementTable;
            _dataSet = dataSet;
            CreateBindingSource();
            _view = new MeasurementTableForm(_bindingSource, _dataSet.Plane);

            _view.cbSelectedPlaneChanged += ComboBox1_SelectedValueChange;
            _view.dataGridView1RowRemoved += DataGridView1_RowRemoved;
            _view.dataGridView1CellValueChanged += DataGridView1_CellValueChanged;
            _view.dataGridViewCellFormattingChanged += DataGridView1_CellValueChanged;
            _view.dataGridViewCellValidating += DataGridView1_CellValidating;
            _view.DataGridView1CellBeginEdit += DataGridView1_CellEditCanacel;
            _view.RevStrokeChanged += CBRevStroke_Changed;
            _view.AdditionFieldsChanged += CBAdditionFieldsVisible_Changed;
            
            _view.cbRevStrokeEnable.Checked = _dataSet.IsRevStrokeEnabled;
            _view.cbAdditionsFileldsEnable.Checked = _dataSet.IsAdditionsFieldEnabled;
            ReverseFieldHandler();
            AdditionFildsHandler();

            //_view.cbRevStrokeEnable.DataBindings.Add("Checked", _dataSet, "IsRevStrokeEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            //_view.cbAdditionsFileldsEnable.DataBindings.Add("Checked", _dataSet, "IsAdditionsFieldEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void CreateBindingSource()
        {
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _model.Table;
    

            //_bindingSource.ResetBindings(false); //Обновление
        }

        //private void DataGridView1_RowAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.RowIndex >= _dataSet.DataTable.Rows.Count)
        //    {
        //        _dataSet.AddRow();
        //    }
        //}


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

        
        private void ComboBox1_SelectedValueChange(object? sender, EventArgs e)
        {
            if (_view.cbPlaneUse.SelectedValue is PryamolineynostWF.Enums.Plane selected)
            {
                _dataSet.Plane = selected;
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //object cellValue = e.Value;

            //if ((cellValue is int intValue && intValue == MeasurementTableModel.DecimalPlaceholder) ||
            //    (cellValue is decimal decValue && decValue == MeasurementTableModel.DecimalPlaceholder))
            //{
            //    e.CellStyle.BackColor = Color.Red;
            //    e.Value = "";
            //    e.FormattingApplied = true;
            //}
            //else
            //{
            //    e.CellStyle.BackColor = Color.White;
            //}
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Получаем имя свойства модели, соответствующее колонке
            string propertyName = _view.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            // Определяем тип данных колонки
            Type propertyType = typeof(MeasurementRowModel).GetProperty(propertyName)?.PropertyType;

            // Если тип данных колонки - decimal
            if (propertyType == typeof(decimal))
            {
                // Пытаемся разобрать строку с учетом разделения запятыми и точками
                string input = e.FormattedValue.ToString().Trim();
                decimal parsedDecimal;

                // Пробуем парсинг с точкой
                if (!decimal.TryParse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out parsedDecimal))
                {
                    // Пробуем парсинг с запятой
                    if (!decimal.TryParse(input.Replace('.', ','), NumberStyles.Any, CultureInfo.InvariantCulture, out parsedDecimal))
                    {
                        // Если оба варианта провалились, сообщаем ошибку
                        MessageBox.Show($"Некорректное значение '{input}' для колонки '{_view.dataGridView1.Columns[e.ColumnIndex].HeaderText}'. Значение должно быть числом.");
                        e.Cancel = true; // Отменяем изменение
                        return;
                    }
                }

                // Если удалось распарсить, устанавливаем правильное значение
                _view.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = parsedDecimal;
            }
        }

        // Помечаем ячейку как некорректную
        private void MarkCellAsInvalid(int rowIndex, int columnIndex, object minValue)
        {
            //_view.dataGridView1.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
            //_view.dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = minValue;
        }

        public void ShowForm()
        {
            _view.Show();
            ApplyColumnHeaders();

        }

        private void ApplyColumnHeaders()
        {
            foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
            {
                if (MeasurementRowModel.ColumnHeaders.ContainsKey(column.DataPropertyName))
                {
                    column.HeaderText = MeasurementRowModel.ColumnHeaders[column.DataPropertyName];
                }
            }
        }

        private void ReverseFieldHandler()
        {
            foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
            {
                if (MeasurementRowModel.ReverseStrokeEnableColumns.Contains(column.DataPropertyName))
                {
                    column.Visible = _dataSet.IsRevStrokeEnabled;
                }
            }
        }

        private void AdditionFildsHandler()
        {
            foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
            {
                if (MeasurementRowModel.AdditionFields.Contains(column.DataPropertyName))
                {
                    column.Visible = _dataSet.IsAdditionsFieldEnabled;
                }
            }
        }

        private void DataGridView1_CellEditCanacel(object sender, DataGridViewCellCancelEventArgs e) 
        {
            if (e.RowIndex == 0)
            {
                e.Cancel = true;
            }
        }

        private void CBRevStroke_Changed(object? sender, EventArgs e) 
        {
            _dataSet.IsRevStrokeEnabled = _view.cbRevStrokeEnable.Checked;
            ReverseFieldHandler();
        }

        private void CBAdditionFieldsVisible_Changed(object? sender, EventArgs e) 
        {
            _dataSet.IsAdditionsFieldEnabled = _view.cbAdditionsFileldsEnable.Checked;
            AdditionFildsHandler();
        }


    }
}
