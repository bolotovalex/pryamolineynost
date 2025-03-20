using System.Data.Common;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel.Tables;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Controllers.Collimator;

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
        
        _view.dataGridViewCellValidating += DataGridView_CellValidating;
        _view.dataGridViewCellEditEnd += DataGridViewC_CellEditEnd;
        _view.dataGridViewCellBeginEdit += DataGridView_CellBeginEdit;
        _view.cbSelectedPlaneChanged += ComboBox1_SelectedValueChange;
        _view.RevStrokeChanged += CBRevStroke_Changed;
        _view.AdditionFieldsChanged += CBAdditionFieldsVisible_Changed;
        _view.cbRevStrokeEnable.Checked = _dataSet.IsRevStrokeEnabled;
        _view.cbAdditionsFileldsEnable.Checked = _dataSet.IsAdditionsFieldEnabled;

        SwitchColumns(_dataSet.Plane);


        //_view.cbRevStrokeEnable.DataBindings.Add("Checked", _table, "IsRevStrokeEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
        //_view.cbAdditionsFileldsEnable.DataBindings.Add("Checked", _table, "IsAdditionsFieldEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void CreateBindingSource()
    {
        _bindingSource = new BindingSource();
        _bindingSource.DataSource = _model.Table;


        //_bindingSource.ResetBindings(false); //Обновление
    }


    private void DataGridView1_RowRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        //var dataGridView = sender as DataGridView;
        //if (dataGridView != null)
        //{
        //    for (int i = 0; i < e.RowCount; i++)
        //    {
        //        int rowIndex = e.RowIndex + i;
        //        if (rowIndex < _table.DataTable.Rows.Count)
        //        {
        //            _table.DataTable.Rows.RemoveAt(rowIndex);
        //        }
        //    }
        //}
    }


    private void SwitchColumns(Enums.Plane plane)
    {
        switch (_dataSet.Plane)
        {
            case Enums.Plane.Horizontal:
                foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
                    column.Visible = MeasurementTableModel.HorizontalFields.Contains(column.DataPropertyName)
                        ? IsAdditionColumnsEnable(column) && IsReverseColumnEnable(column)
                        : false;
                break;

            case Enums.Plane.Vertical:
                foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
                    column.Visible = MeasurementTableModel.VerticalFields.Contains(column.DataPropertyName)
                        ? IsAdditionColumnsEnable(column) && IsReverseColumnEnable(column)
                        : false;
                break;

            case Enums.Plane.Both:
                foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
                    column.Visible = IsAdditionColumnsEnable(column) && IsReverseColumnEnable(column);
                break;
        }
    }

    private void ComboBox1_SelectedValueChange(object? sender, EventArgs e)
    {
        if (_view.cbPlaneUse.SelectedValue is Enums.Plane selected) _dataSet.Plane = selected;
        _model.Plane = _dataSet.Plane;
        SwitchColumns(_dataSet.Plane);
    }

    private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        // Получаем имя свойства модели, соответствующее колонке
        var propertyName = _view.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

        // Определяем тип данных колонки
        var propertyInfo = typeof(MeasurementRowModel).GetProperty(propertyName);
        if (propertyInfo == null)
            return;


        var propertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
        var input = e.FormattedValue?.ToString().Trim();

        // Если значение пустое и тип nullable, устанавливаем null
        if (string.IsNullOrEmpty(input) && propertyInfo.PropertyType.IsGenericType &&
            propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            _view.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
            return;
        }

        // Валидация для строк
        if (propertyType == typeof(string))
        {
            e.Cancel = true;
            return;
        }

        // Валидация для decimal и decimal?
        if (propertyType == typeof(decimal))
        {
            decimal parsedDecimal;

            // Пробуем парсинг с точкой
            if (!decimal.TryParse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out parsedDecimal))
            {
                // Пробуем парсинг с запятой
                if (!decimal.TryParse(input.Replace('.', ','), NumberStyles.Any, CultureInfo.InvariantCulture, out parsedDecimal))
                {
                    // Если оба варианта провалились, устанавливаем null и окрашиваем ячейку
                    _view.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                    e.Cancel = true;
                    return;
                }
            }

            // Если удалось распарсить, устанавливаем правильное значение
            _view.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = parsedDecimal;
        }

        // Валидация для int и int?
        else if (propertyType == typeof(int))
        {
            int parsedInt;

            if (!int.TryParse(input, out parsedInt))
            {
                // Если парсинг не удался, устанавливаем null и окрашиваем ячейку
                _view.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                e.Cancel = true;
                return;
            }

            // Если удалось распарсить, устанавливаем правильное значение
            _view.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = parsedInt;
        }
    }

    public void ShowForm()
    {
        _view.Show();
        ApplyColumnHeaders();
        ApplyReadonlyArgs();
    }

    private void ApplyReadonlyArgs()
    {
        foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
            if (MeasurementTableModel.ReadonlyColumns.Contains(column.DataPropertyName))
                column.ReadOnly = true;
    }

    private void ApplyColumnHeaders()
    {
        foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
            if (MeasurementTableModel.ColumnHeaders.ContainsKey(column.DataPropertyName))
                column.HeaderText = MeasurementTableModel.ColumnHeaders[column.DataPropertyName];
    }

    private bool IsReverseColumnEnable(DataGridViewColumn column)
    {
        if (MeasurementTableModel.ReverseStrokeEnableColumns.Contains(column.DataPropertyName))
            return _dataSet.IsRevStrokeEnabled;
        return true;
    }

    private bool IsAdditionColumnsEnable(DataGridViewColumn column)
    {
        if (MeasurementTableModel.AdditionFields.Contains(column.DataPropertyName))
            return _dataSet.IsAdditionsFieldEnabled;
        return true;
    }

   
    private void CBRevStroke_Changed(object? sender, EventArgs e)
    {
        _dataSet.IsRevStrokeEnabled = _view.cbRevStrokeEnable.Checked;
        SwitchColumns(_dataSet.Plane);
    }

    private void CBAdditionFieldsVisible_Changed(object? sender, EventArgs e)
    {
        _dataSet.IsAdditionsFieldEnabled = _view.cbAdditionsFileldsEnable.Checked;
        SwitchColumns(_dataSet.Plane);
    }

    private void DataGridView_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
    {
        if (MeasurementTableModel.ReadonlyColumns.Contains(_view.dataGridView1.Columns[e.ColumnIndex].DataPropertyName))
        {
            e.Cancel = true;
            return;
        }
    }

    private void DataGridViewC_CellEditEnd(object? sender, DataGridViewCellEventArgs e)
    {
        if (_model.Table.Count <= e.RowIndex + 1)
        {
            _model.Table.Add(new MeasurementRowModel(_model.Step, _model.Table[^1], _model.IsRevStrokeEnabled));
        }
        else
        {
            var row = _model.Table[e.RowIndex];
            var horizontalForwardHasValue = row.ForwardDegreesHorizontal.HasValue || row.ForwardMinutesHorizontal.HasValue || row.ForwardSecondsHorizontal.HasValue;
            var horizontalReverseHasValue = row.ReverseDegreesHorizontal.HasValue || row.ReverseMinutesHorizontal.HasValue || row.ReverseSecondsHorizontal.HasValue;
            
            var verticalForwardHasValue = row.ForwardDegreesVertical.HasValue || row.ForwardMinutesVertical.HasValue || row.ForwardSecondsVertical.HasValue;
            var verticalReverseHasValue = row.ReverseDegreesVertical.HasValue || row.ReverseMinutesVertical.HasValue || row.ReverseSecondsVertical.HasValue;

            if (_model.Plane == Enums.Plane.Horizontal)
            {
                if (!horizontalForwardHasValue && (!_model.IsRevStrokeEnabled || !horizontalReverseHasValue))
                {
                    _model.Table.RemoveAt(e.RowIndex);
                    UpdatePositions();
                }
                
            }

            else if (_model.Plane == Enums.Plane.Vertical)
            {
                if (!verticalForwardHasValue && (!_model.IsRevStrokeEnabled || !verticalReverseHasValue))
                {
                    _model.Table.RemoveAt(e.RowIndex);
                    UpdatePositions();
                }
            }
            
            else if (_model.Plane == Enums.Plane.Both)
            {
                if (!horizontalForwardHasValue && !verticalForwardHasValue && (!_model.IsRevStrokeEnabled || (!verticalReverseHasValue && !horizontalForwardHasValue)))
                {
                    _model.Table.RemoveAt(e.RowIndex);
                    UpdatePositions();
                }
            }
        }
    }

    private void UpdatePositions()
    {
        for (var i = 1; i < _model.Table.Count; i++)
        {
            var row = _model.Table[i];
            row.PreviousDataRow = _model.Table[i - 1];
            row.UpdatePosition(i);
        }
    }
}