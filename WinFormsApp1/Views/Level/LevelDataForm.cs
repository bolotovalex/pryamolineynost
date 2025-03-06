using LogicLibrary;
using PryamolineynostWF.Enums;
using System;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace Pryamolineynost;

public partial class LevelDataForm : Form
{
    private DB _db;
    private LevelMainForm _mainForm;
    private readonly LevelGraphicsForm _graphicsForm;
    private bool _initFlag;
    private int[] _micrometersColumnsIndex = new int[] { 7, 8 };
    private int[] _angleColumnsIndex = new int[] { 9, 10, 11, 12, 13, 14 };
    private ContextMenuStrip contextMenu;

    public LevelDataForm(DB db, LevelMainForm parrentForm, LevelGraphicsForm graphicsForm)
    {
        _initFlag = true;
        this._db = db;
        _mainForm = parrentForm;
        this._graphicsForm = graphicsForm;
        InitializeComponent();
        FillUnitsComboBox();
        ToogleUnitsColumns();
        _initFlag = false;
        dataGrid.AllowUserToAddRows = true;
        dataGrid.AllowUserToDeleteRows = true;
        InitializeContextMenu();
        dataGrid.CellMouseDown += DataGridView_CellMouseDown;
        Controls.Add(dataGrid);
    }

    private void InitializeContextMenu()
    {
        contextMenu = new ContextMenuStrip();
        var deleteRowMenuItem = new ToolStripMenuItem("Удалить строку");
        deleteRowMenuItem.Click += DeleteRowMenuItem_Click;
        contextMenu.Items.Add(deleteRowMenuItem);
    }

    private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex > 0)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                dataGridView.ClearSelection();
                dataGridView.Rows[e.RowIndex].Selected = true; // Выделить строку
                contextMenu.Show(Cursor.Position); // Показать контекстное меню
            }
        }
    }

    private void DeleteRowMenuItem_Click(object sender, EventArgs e)
    {
        var dataGridView = Controls[5] as DataGridView;
        if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
        {
            foreach (DataGridViewRow selectedRow in dataGridView.SelectedRows)
            {
                if (!selectedRow.IsNewRow)
                {
                    _db.DataList.RemoveAt(selectedRow.Index);
                    dataGrid.Rows.RemoveAt(selectedRow.Index);
                    _db.UpdateAllRows(_db.currUnit);
                    UpdateForm(sender, e);
                    _mainForm.UpdateAllFields();
                    _mainForm.UpdateGraphic();
                    if (_graphicsForm != null)
                    {
                        _graphicsForm.UpdateDeviationList();
                    }
                }
            }
        }
    }

    public void FillUnitsComboBox()
    {
        unitComboBox.Items.Clear();
        unitComboBox.Items.Add(_db.GetUnitDescription(Units.Micrometer));
        unitComboBox.Items.Add(_db.GetUnitDescription(Units.Angle));
        unitComboBox.SelectedIndex = _db.GetUnitOrder(_db.currUnit);
    }
    public void ReloadDataForm(DB db, LevelMainForm parrentForm)
    {
        this._db = db;
        _mainForm = parrentForm;
        dataGrid.Rows.Clear();
        UpdateForm(null, null);
    }


    private void DataForm_SizeChanged(object sender, EventArgs e)
    {
        dataGrid.Size = new Size(ClientSize.Width - 6, ClientSize.Height - 36);
        closeButton.Location = new Point(ClientSize.Width - 79, ClientSize.Height - 28);
        revStrokeCheckBox.Location = new Point(ClientSize.Width - 188, ClientSize.Height - 25);
        clearDBButton.Location = new Point(clearDBButton.Location.X, ClientSize.Height - 28);
        UnitLabel.Location = new Point(ClientSize.Width - 511, ClientSize.Height - 24);
        unitComboBox.Location = new Point(ClientSize.Width - 387, ClientSize.Height - 28);

    }

    public void DataForm_Load(object sender, EventArgs e)
    {
        dataGrid.Rows.Clear();
        if (dataGrid.Columns.Count == 0)
            InitializeComponent();
        dataGrid.Rows.Add();
        UpdateForm(sender, e);
    }

    public void UpdateForm(object? sender, EventArgs? e)
    {
        if (dataGrid.Rows.Count < _db.DataList.Count)
        {
            if (dataGrid.Columns.Count == 0)
                InitializeComponent();
            for (var i = dataGrid.Rows.Count; i <= _db.DataList.Count; i++)
                dataGrid.Rows.Add();
        }


        for (var i = 0; i < _db.DataList.Count; i++)
        {
            var row = _db.DataList[i];
            for (var cellNumber = 0; cellNumber < dataGrid.ColumnCount; cellNumber++)
            {
                dataGrid.Rows[i].Cells[cellNumber].Style.BackColor = Color.WhiteSmoke;
            }
            dataGrid.Rows[i].Cells[0].Value = i;
            dataGrid.Rows[i].Cells[1].Value = row.Position;
            dataGrid.Rows[i].Cells[2].Value = Math.Round(row.FactProfile, 2);
            dataGrid.Rows[i].Cells[3].Value = Math.Round(row.AdjStraight, 2);
            dataGrid.Rows[i].Cells[4].Value = Math.Round(row.Deviation, 2);
            dataGrid.Rows[i].Cells[5].Value = Math.Round(row.DeviationPerMeter, 2);
            dataGrid.Rows[i].Cells[6].Value = Math.Round(row.MidValue, 2);
            dataGrid.Rows[i].Cells[7].Value = row.FStroke == int.MinValue ? "" : row.FStroke.ToString();
            dataGrid.Rows[i].Cells[8].Value = row.RevStroke == int.MinValue ? "" : row.RevStroke.ToString();
            dataGrid.Rows[i].Cells[9].Value = row.FDegree == int.MinValue ? "" : row.FDegree.ToString();
            dataGrid.Rows[i].Cells[10].Value = row.FMinutes == int.MinValue ? "" : row.FMinutes.ToString();
            dataGrid.Rows[i].Cells[11].Value = row.FSeconds == int.MinValue ? "" : row.FSeconds.ToString();
            dataGrid.Rows[i].Cells[12].Value = row.RevDegree == int.MinValue ? "" : row.RevDegree.ToString();
            dataGrid.Rows[i].Cells[13].Value = row.RevMinutes == int.MinValue ? "" : row.RevMinutes.ToString();
            dataGrid.Rows[i].Cells[14].Value = row.RevSeconds == int.MinValue ? "" : row.RevSeconds.ToString();

            if (Math.Round(row.DeviationPerMeter, 2) > this._db.MeterTolerance)
                dataGrid.Rows[i].Cells[5].Style.BackColor = Color.LightCoral;
            else
                dataGrid.Rows[i].Cells[5].Style.BackColor = SystemColors.Control;
        }
    }

    private void ToogleUnitsColumns()
    {
        foreach (var index in _micrometersColumnsIndex)
            dataGrid.Columns[index].Visible = _db.currUnit == Units.Micrometer;

        foreach (var index in _angleColumnsIndex)
            dataGrid.Columns[index].Visible = _db.currUnit == Units.Angle;
        ToogleRevStrokeColumns();
    }

    private void ToogleRevStrokeColumns()
    {
        var mStartIndex = _micrometersColumnsIndex.Length / 2;
        var aStartIndex = _angleColumnsIndex.Length / 2;

        if (_db.RevStrokeEnable)
            dataGrid.Columns[6].Visible = true;
        else
            dataGrid.Columns[6].Visible = false;

        for (var i = mStartIndex; i < _micrometersColumnsIndex.Length; i++)
            dataGrid.Columns[_micrometersColumnsIndex[i]].Visible = _db is { RevStrokeEnable: true, currUnit: Units.Micrometer };

        for (var i = aStartIndex; i < _angleColumnsIndex.Length; i++)
            dataGrid.Columns[_angleColumnsIndex[i]].Visible = _db is { RevStrokeEnable: true, currUnit: Units.Angle };
    }

    
    private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        object? cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        int value;

        if (cellValue != null)
        {
            int.TryParse(cellValue.ToString(), out value);
            if (e.RowIndex == _db.DataList.Count)
                switch (e.ColumnIndex)
                {
                    case 7:
                        _db.AddRow(value, Direction.Forward, Units.Micrometer);
                        break;
                    case 8:
                        _db.AddRow(value, Direction.Reverse, Units.Micrometer);
                        break;
                    case 9:
                        _db.AddRow(value, Direction.Forward, Units.Angle, AngleUnits.Degree);
                        break;
                    case 10:
                        _db.AddRow(value, Direction.Forward, Units.Angle, AngleUnits.Minute);
                        break;
                    case 11:
                        _db.AddRow(value, Direction.Forward, Units.Angle);
                        break;
                    case 12:
                        _db.AddRow(value, Direction.Reverse, Units.Angle, AngleUnits.Degree);
                        break;
                    case 13:
                        _db.AddRow(value, Direction.Reverse, Units.Angle, AngleUnits.Minute);
                        break;
                    case 14:
                        _db.AddRow(value, Direction.Reverse, Units.Angle);
                        break;
                }
            else
                switch (e.ColumnIndex)
                {
                    case 7:
                        _db.UpdateRow(e.RowIndex, value, Direction.Forward, Units.Micrometer);
                        break;
                    case 8:
                        _db.UpdateRow(e.RowIndex, value, Direction.Reverse, Units.Micrometer);
                        break;
                    case 9:
                        _db.UpdateRow(e.RowIndex, value, Direction.Forward, Units.Angle, AngleUnits.Degree);
                        break;
                    case 10:
                        _db.UpdateRow(e.RowIndex, value, Direction.Forward, Units.Angle, AngleUnits.Minute);
                        break;
                    case 11:
                        _db.UpdateRow(e.RowIndex, value, Direction.Forward, Units.Angle);
                        break;
                    case 12:
                        _db.UpdateRow(e.RowIndex, value, Direction.Reverse, Units.Angle, AngleUnits.Degree);
                        break;
                    case 13:
                        _db.UpdateRow(e.RowIndex, value, Direction.Reverse, Units.Angle, AngleUnits.Minute);
                        break;
                    case 14:
                        _db.UpdateRow(e.RowIndex, value, Direction.Reverse, Units.Angle);
                        break;
                }
        }
        
        else
        {
            switch (e.ColumnIndex)
            {
                case 7:
                    if (_db.DataList[e.RowIndex].RevStroke == int.MinValue)
                    {
                        _db.DataList.RemoveAt(e.RowIndex);
                        dataGrid.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        _db.UpdateRow(e.RowIndex, 0, Direction.Forward, Units.Micrometer);
                        //dataGrid.Rows.RemoveAt(e.RowIndex);
                    }
                    break;

                case 8:
                    if (_db.DataList[e.RowIndex].FStroke == int.MinValue)
                    {
                        _db.DataList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        _db.UpdateRow(e.RowIndex, int.MinValue, Direction.Reverse, Units.Micrometer);
                    }
                    break;
            }

            _db.UpdateAllRows(_db.currUnit);
        }

        UpdateForm(sender, e);
        _mainForm.UpdateAllFields();
        _mainForm.UpdateGraphic();
        if (_graphicsForm != null)
        {
            _graphicsForm.UpdateDeviationList();
        }
    }


    private void CloseButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ClearDBButton_Click(object sender, EventArgs e)
    {
        while (dataGrid.RowCount > 2) dataGrid.Rows.RemoveAt(1);
        _db.CleanDb();
        _mainForm.UpdateAllFields();
        UpdateForm(sender, e);
        if (_graphicsForm != null)
            _graphicsForm.UpdatePlot();
    }


    private void revStrokeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _db.RevStrokeEnable = revStrokeCheckBox.Checked;
        _db.UpdateAllRows(_db.currUnit);
        UpdateForm(sender, e);
        ToogleRevStrokeColumns();
        _mainForm.UpdateAllFields();
    }

    private void unitComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_initFlag && _db.GetUnitFromIndex(unitComboBox.SelectedIndex) != _db.currUnit && _db.DataList.Count > 1)
        {
            DialogResult = MessageBox.Show(
                "Произойдет смена и пересчет единиц измерения. Продолжить?",
                "Внимание",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if (DialogResult == DialogResult.Yes)
            {
                _db.currUnit = _db.GetUnitFromIndex(unitComboBox.SelectedIndex);
                ToogleUnitsColumns();
            }
        }
        else
        {
            _db.currUnit = _db.GetUnitFromIndex(unitComboBox.SelectedIndex);
            ToogleUnitsColumns();
        }


        //var unit = db.GetUnitFromIndex(unitComboBox.SelectedIndex);
        //db.currUnit = unit;

        //var angelColumns = new int[] { 9, 10, 11, 12, 13, 14 };
        //var micrometersColumns = new int[] { 7, 8 };

        //var isMicrometer = unit == Units.Micrometer;

        //for (int i = micrometersColumns[0]; i <= micrometersColumns[^1]; i++)
        //    dataGrid.Columns[i].Visible = isMicrometer;

        //for (int i = angelColumns[0]; i <= angelColumns[^1]; i++)
        //    dataGrid.Columns[i].Visible = !isMicrometer;
    }

    private (int degree, int minutes, int seconds) GetAngelFromMicroMeters(int micrometers)
    {
        var degree = Decimal.ToInt32(micrometers / 17455);
        var minutes = Decimal.ToInt32(micrometers / 290.916666666667M);
        var seconds = Decimal.ToInt32(micrometers / 4.84861111111111M);
        return (degree, minutes, seconds);

    }

    
}