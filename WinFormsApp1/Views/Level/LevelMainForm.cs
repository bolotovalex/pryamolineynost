using System.Globalization;
using System.Text.Json;
using LogicLibrary;
using PryamolineynostWF;
using PryamolineynostWF.Interfaces;

namespace Pryamolineynost;

public partial class LevelMainForm : Form, IView
{
    
    private string _version = "1.2.7.2";
    private DB _dB;
    private LevelDataForm _dataForm;
    private LevelGraphicsForm _graphicsForm;
    private GraphicModel _graphic;
    private ErrorForm _errorForm;
       
    enum FileFormat
    {
        Json,
        Pdf
    }

    public LevelMainForm()
    {
        InitializeComponent();
        _dB = new DB() { Description = "", Name = "", Fio = "" };
        //_dataForm = new DataForm(_dB, this, _graphicsForm);
        stepTextBox.Text = _dB.Step.ToString();
        _graphic = new GraphicModel(_dB.GetCurvePoints(), _dB.GetStraightPoint(), _dB.Step);
        ChangeComboBoxColor();
        //_graphicsForm = new GraphicsForm(_dB, this, _graphic);
        Text = $"Прямолинейность. ver. {_version}";
    }

    public bool CheckComboBox(ComboBox comboBox)
    {
        if (comboBox.Text.Length == 0)
            return false;
        return true;
    }

    private bool ChangeComboBoxColor()
    {
        var state = true;
        foreach (var cb in new ComboBox[] { nameComboBox, descriptionComboBox, fioComboBox })
        {
            var st = CheckComboBox(cb);
            state = state & st;
            UpdateFieldColor(cb, st);
        }

        foreach (var tb in new TextBox[] { tolerLenghtTextBox, tolerPerMeterTextBox })
        {
            var st = int.Parse(tb.Text) != 0;
            state = state & st;
            UpdateFieldColor(tb, st);
        }

        return state;
    }

    public void UpdateFieldColor(ComboBox field, bool state)
    {
        field.BackColor = state ? Color.White : Color.LightCoral;
    }

    public void UpdateFieldColor(TextBox field, bool state)
    {
        field.BackColor = state ? Color.White : Color.LightCoral;
    }

    private void UpdateFio(object sender, EventArgs e)
    {
        var state = CheckComboBox(fioComboBox);
        UpdateFieldColor(fioComboBox, state);
        _dB.Fio = fioComboBox.Text;
    }

    private void UpdateProjectName(object sender, EventArgs e)
    {
        var state = CheckComboBox(nameComboBox);
        UpdateFieldColor(nameComboBox, state);
        _dB.Name = nameComboBox.Text;
    }

    private void DescriptionComboBox_TextChanged(object sender, EventArgs e)
    {
        var state = CheckComboBox(descriptionComboBox);
        UpdateFieldColor(descriptionComboBox, state);
        _dB.Description = descriptionComboBox.Text;
    }


    private static int CheckTextBoxIntValue(TextBox textBox)
    {
        return int.TryParse(textBox.Text, out int result) ? result : 0;
    }


    private void UpdateStep(object sender, EventArgs e)
    {
        _dB.Step = CheckTextBoxIntValue(stepTextBox);
        _dB.UpdateStepsPerMeter(_dB.Step);
        _dB.UpdateAllRows(_dB.currUnit);
        if (_dataForm != null && !_dataForm.Disposing)
        {
            _dataForm.DataForm_Load(sender, e);
        }
        
        UpdateAllFields();
        if (_graphic != null)
        {
            _graphic.RefreshPlot();
        }
        if (_dB.GetAreaDeviations().Length > 0)
        {
            lineDeviationTextBox.Text = _dB.GetAreaDeviations()[0].deviation.ToString();
        }
    }

    private void UpdateFullTolerance(object sender, EventArgs e)
    {
        _dB.FullTolerance = CheckTextBoxIntValue(tolerLenghtTextBox);
        UpdateFieldColor(tolerLenghtTextBox, _dB.FullTolerance > 0);
        UpdateAllFields();
    }

    private void UpdateAdmPerMeter(object sender, EventArgs e)
    {
        _dB.MeterTolerance = CheckTextBoxIntValue(tolerPerMeterTextBox);
        UpdateFieldColor(tolerPerMeterTextBox, _dB.MeterTolerance > 0);
        UpdateAllFields();
    }


    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void DataForm_Click(object sender, EventArgs e)
    {
        if (ChangeComboBoxColor())
        {
            //_dataForm.Dispose();
            _dataForm = new LevelDataForm(_dB, this, _graphicsForm);
            _dataForm.Show();
        }
        else
        {
            _errorForm = new ErrorForm();
            _errorForm.ShowDialog();
        }
    }

    public static string GetSrting(decimal value)
    {
        return Math.Round(value, 2).ToString(CultureInfo.InvariantCulture).ToString();
    }

    public void UpdateAllFields()
    {
        dateTimePicker.Value = _dB.Date;
        nameComboBox.Text = _dB.Name;
        descriptionComboBox.Text = _dB.Description;
        fioComboBox.Text = _dB.Fio;
        minDeviationTextBox.Text = Math.Round(_dB.GetMinDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        maxDeviationTextBox.Text = Math.Round(_dB.GetMaxDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        localAreaTextBox.Text = _dB.LocalAreaLength.ToString();
        bedLengthTextBox.Text = _dB.DataList[^1].Position.ToString();
        tolerLenghtTextBox.Text = _dB.FullTolerance.ToString(CultureInfo.InvariantCulture);
        tolerPerMeterTextBox.Text = _dB.MeterTolerance.ToString(CultureInfo.InvariantCulture);
        stepTextBox.Text = _dB.Step.ToString();
        lineDeviationTextBox.Text = GetSrting(_dB.GetAreaDeflection());
        verticalDeviationTextBox.Text = GetSrting(_dB.GetVerticalDeflection());
    }


    private async void SaveButton_Click(object sender, EventArgs e)
    {
        if (ChangeComboBoxColor())
        {
            var filename = GetSaveFileName(FileFormat.Json);

            if (filename != "")
            {
                using var writer = new StreamWriter(filename);
                await writer.WriteLineAsync(JsonSerializer.Serialize(_dB));
                writer.Close();
            }
        }
        else
        {
            _errorForm = new ErrorForm();
            _errorForm.ShowDialog();
        }
    }

    private static string GetSaveFileName(FileFormat format)
    {
        var saveFileDialog = new SaveFileDialog();

        switch (format)
        {
            case FileFormat.Pdf:
                saveFileDialog.Filter = @"PDF|*.pdf";
                saveFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.Json:
                saveFileDialog.Filter = @"JSON|*.json";
                saveFileDialog.Title = @"Select JSON file";
                break;
        }

        saveFileDialog.ShowDialog();

        return saveFileDialog.FileName;
    }

    private async void LoadFileButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = @"Json|*.json",
            Title = @"Load json file"
        };
        openFileDialog.ShowDialog();
        if (openFileDialog.FileName != "")
        {
            if (_dataForm != null && !_dataForm.Disposing)
            {
                _dataForm.Dispose();
            }
            
            if (_graphicsForm != null)
            {
                _graphicsForm.Dispose();
            }


            var reader = new StreamReader(openFileDialog.OpenFile());
            var data = await reader.ReadToEndAsync();
            DB? newDb = JsonSerializer.Deserialize<DB>(data) ?? new DB() { Description = "", Name = "", Fio = "" };
            _dB = newDb;
            _dB.UpdateAllRows(_dB.currUnit);
            UpdateAllFields();
            if (_dataForm != null && !_dataForm.Disposing)
            {
                _dataForm.UpdateForm(null, null);
            }
            UpdateGraphic();
            reader.Close();
        }
        else
        {
            //_errorForm = new ErrorForm();
            //_errorForm.ShowDialog();
        }
        ChangeComboBoxColor();
    }

    public void UpdateGraphic()
    {
        _dB.UpdatePoints();
        _graphic.CurvePoints = _dB.GetCurvePoints();
        _graphic.StraightPoints = _dB.GetStraightPoint();
        _graphic.RefreshPlot();
    }
    private void GraphicButton_Click(object sender, EventArgs e)
    {
        if (ChangeComboBoxColor())
        {
            if (_graphicsForm != null)
                _graphicsForm.Dispose();

            var newGraphic = new GraphicModel(_dB.GetCurvePoints(), _dB.GetStraightPoint(), _dB.DataList.Count < 12 ? _dB.Step : _dB.DataList.Count / 12 * _dB.Step);
            _graphicsForm = new LevelGraphicsForm(_dB, this, newGraphic);
            _graphicsForm.UpdateDeviationList();
            _graphicsForm.Show();
        }
        else
        {
            _errorForm = new ErrorForm();
            _errorForm.ShowDialog();
        }
    }

    private void SavePdfButton_Click(object sender, EventArgs e)
    {
        if (ChangeComboBoxColor())
        {
            var fileName = GetSaveFileName(FileFormat.Pdf);
            var pl = new GraphicModel(_dB.GetCurvePoints(), _dB.GetStraightPoint(), _dB.DataList.Count < 12 ? _dB.Step : _dB.DataList.Count / 12 * _dB.Step);
            pl.RefreshPlot();
            if (fileName != "")
            {
                var document = PdfService.CreateDocument(
                    _dB.GetPrintLists().dbValues,
                    _dB.GetPrintLists().dataListValues,
                    pl.GetPlotModel());
                document.Save(fileName);
            }
        }
        else
        {
            _errorForm = new ErrorForm();
            _errorForm.ShowDialog();
        }
    }

    private void dateTimePicker_DropDown(object sender, EventArgs e)
    {
        _dB.Date = dateTimePicker.Value.Date;
    }

    private void localAreaTextBox_TextChanged(object sender, EventArgs e)
    {
        _dB.LocalAreaLength = CheckTextBoxIntValue(localAreaTextBox);
        if (_dB.LocalAreaLength >= _dB.Step)
        {
            _dB.SetAreaDeviation(_dB.GetMaxLocalAreaDeviation(30));
            if (_graphicsForm != null)
            {
                _graphicsForm.UpdateDeviationList();
            }

            if (_graphic != null)
            {
                _graphic.UpdataSeries();
                _graphic.RefreshPlot();
            }
        }
        if (_graphic != null)
        {
            _graphic.RebuildModel(_dB.Step);
            _graphic.RefreshPlot();
        }

        if (_dB.GetAreaDeviations().Length > 0)
        {
            lineDeviationTextBox.Text = _dB.GetAreaDeviations()[0].deviation.ToString();
        }
    }
}