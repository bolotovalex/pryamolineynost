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
        _view.cbSelectedPlaneChanged += PlainComboBox_SelectedValueChange;
        _view.RevStrokeChanged += CBRevStroke_Changed;
        _view.AdditionFieldsChanged += CBAdditionFieldsVisible_Changed;
        _view.cbRevStrokeEnable.Checked = _dataSet.IsRevStrokeEnabled;
        _view.cbAdditionsFileldsEnable.Checked = _dataSet.IsAdditionsFieldEnabled;
        _view.BtnAddClicked += BtnAddClicked;
        _view.BtnDelClicked += BtnDelClicked;
        _view.BtnCopyClicked += BtnCopyClicked;

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


    private void SwitchColumns(Enums.Plane plane)
    {
        switch (_dataSet.Plane)
        {
            case Enums.Plane.Horizontal:
                foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
                    column.Visible = MeasurementTableModel.HorizontalFields.Contains(column.DataPropertyName)
                                     && (IsAdditionColumnsEnable(column)
                                         && IsReverseColumnEnable(column));
                break;

            case Enums.Plane.Vertical:
                foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
                    column.Visible = MeasurementTableModel.VerticalFields.Contains(column.DataPropertyName)
                                     && (IsAdditionColumnsEnable(column) && IsReverseColumnEnable(column));
                break;

            case Enums.Plane.Both:
                foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
                    column.Visible = IsAdditionColumnsEnable(column) && IsReverseColumnEnable(column);
                break;
        }
    }

    private void PlainComboBox_SelectedValueChange(object? sender, EventArgs e)
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

        // Валидация для decimal и decimal?
        if (propertyType == typeof(decimal))
        {
            decimal parsedDecimal;

            // Пробуем парсинг с точкой
            if (!decimal.TryParse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture,
                    out parsedDecimal))
            {
                // Пробуем парсинг с запятой
                if (!decimal.TryParse(input.Replace('.', ','), NumberStyles.Any, CultureInfo.InvariantCulture,
                        out parsedDecimal))
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
    }

    private void ApplyColumnHeaders()
    {
        foreach (DataGridViewColumn column in _view.dataGridView1.Columns)
        {
            if (MeasurementTableModel.ColumnHeaders.ContainsKey(column.DataPropertyName))
                column.HeaderText = MeasurementTableModel.ColumnHeaders[column.DataPropertyName];
            if (MeasurementTableModel.ColumnFormat.ContainsKey(column.DataPropertyName))
                _view.dataGridView1.Columns[column.DataPropertyName].DefaultCellStyle.Format = MeasurementTableModel.ColumnFormat[column.DataPropertyName];
        }
            
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
        if (e.RowIndex == 0)
        {
            e.Cancel = true;
        }
    }

    private void DataGridViewC_CellEditEnd(object? sender, DataGridViewCellEventArgs e)
    {
        
        _model.UpdateTableRow(e.RowIndex);
        _dataSet.UpdateBedLength();
    }

    private void BtnAddClicked(object? sender, EventArgs e)
    {

    }

    private void BtnDelClicked(object? sender, EventArgs e)
    {
    }

    private void BtnCopyClicked(object? sender, EventArgs e)
    {

    }


}