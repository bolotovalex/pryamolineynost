using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PryamolineynostWF.DTO.Collimator;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;

namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    public CollimatorForm View { get; init; }
    private readonly CollimatorModel _model;


    public
        CollimatorController(CollimatorType collimatorType, DateTime date, string actNumber)
    {
        _model = new CollimatorModel();
        View = new CollimatorForm(collimatorType, date, actNumber);


        Initialization(collimatorType, date, actNumber);
        BindingTextBoxData();
        BindinLabelData();
        BindButtonActions();

        View.Show();
    }

    //public Form View() => View;
    private void StubFormShow(object sender, EventArgs e)
    {
        MessageBox.Show("В разработке",
            "В разработке",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
    }

    private void Initialization(CollimatorType collimatorType, DateTime collimatorCheckDate, string actNumber)
    {
        _model.MeasurementDate = DateTime.Now;
        _model.CollimatorType = collimatorType;
        _model.CollimatorCheckDate = collimatorCheckDate;
        _model.ActNumber = actNumber;
        _model.ObjectName = "";
        _model.Description = "";
        _model.WorkerName = "";
    }

    private void BindingTextBoxData()
    {
        View.GetDateTimeControl.DataBindings.Add("Value", _model, "MeasurementDate", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbObjectName.DataBindings.Add("Text", _model, "ObjectName", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbDescription.DataBindings.Add("Text", _model, "Description", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbWorkerName.DataBindings.Add("Text", _model, "WorkerName", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbLocalAreaSize.DataBindings.Add("Text", _model, "LocalAreaSize", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbHorizontalTolerLocalAreaSize.DataBindings.Add("Text", _model, "HorizontalTolerLocalAreaSize", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbHorizontalTolerAllLength.DataBindings.Add("Text", _model, "HorizontalTolerAllLength", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbVerticalTolerLocalAreaSize.DataBindings.Add("Text", _model, "VerticalTolerLocalAreaSize", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbVerticalTolerAllLength.DataBindings.Add("Text", _model, "VerticalTolerAllLength", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetTbStepSize.DataBindings.Add("Text", _model, "StepSize", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void BindinLabelData()
    {
        View.GetLblColimmatorType.DataBindings.Add("Text", _model, "CollimatorType", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblBedLength.DataBindings.Add("Text", _model, "BedLength", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblHorizontalMaxDeviation.DataBindings.Add("Text", _model, "HorizontalMaxDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblVerticalMaxDeviation.DataBindings.Add("Text", _model, "VerticalMaxDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblHorizontalMinDeviation.DataBindings.Add("Text", _model, "HorizontalMinDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblVericalMinDeviation.DataBindings.Add("Text", _model, "VerticalMinDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblHorizontalMeanDeviation.DataBindings.Add("Text", _model, "HorizontalMeanDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblVerticalMeanDeviation.DataBindings.Add("Text", _model, "VerticalMeanDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblHorizontalLineDeviation.DataBindings.Add("Text", _model, "HorizontalAreaDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        View.GetLblVerticalLineDeviation.DataBindings.Add("Text", _model, "VerticalAreaDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
    }

    private void BindButtonActions()
    {
        View.btnShowDataFormClicked += ShowMeasurementForm;
        View.btnGraphicFormClicked += StubFormShow;
        View.btnPdfFormClicked += StubFormShow;
        View.btnExitClicked += StubFormShow;
        View.btnSaveChangedClicked += (Sender, e) => SaveToJson();
        View.btnLoadChangedClicked += (Sender, e) => LoadFromJson();
        View.btnCollimatorTypeChangeClicked += StubFormShow;
    }


    private void ShowMeasurementForm(object sender, EventArgs e)
    {
        var measurementController = new MeasurementTableController(_model);
        measurementController.ShowForm();
    }

    public void SwitchPlane(Plane plane)
    {
        View.SwitchPlane(plane);
    }

    public void SaveToJson()
    {
        var filePath = GetSaveFileName(FileFormat.JSON);
        if (filePath != string.Empty)
        {
            try
            {
                var dto = new CollimatorModelDTO()
                {
                    DTOVersion = _model.ModelVersion,
                    DTOTool = "Autocollimator",
                    MeasurementDate = _model.MeasurementDate,
                    CollimatorCheckDate = _model.CollimatorCheckDate,
                    CollimatorType = _model.CollimatorType,
                    ActNumber = _model.ActNumber,
                    ObjectName = _model.ObjectName,
                    Description = _model.Description,
                    WorkerName = _model.WorkerName,
                    LocalAreaSize = _model.LocalAreaSize,
                    HorizontalTolerLocalAreaSize = _model.HorizontalTolerLocalAreaSize,
                    HorizontalTolerAllLength = _model.HorizontalTolerAllLength,
                    VerticalTolerLocalAreaSize = _model.VerticalTolerLocalAreaSize,
                    VerticalTolerAllLength = _model.VerticalTolerAllLength,
                    StepSize = _model.StepSize,
                    BedLength = _model.BedLength,
                    IsRevstrokeEnabled = _model.IsRevStrokeEnabled,
                    Plane = _model.Plane,
                    IsAddtionsFieldEnabled = _model.IsAdditionsFieldEnabled,
                    Table = new MeasurementTableModelDTO
                    {
                        Plane = _model.MeasurementTable.Plane,
                        Step = _model.MeasurementTable.Step,
                        IsRevStrokeEnabled = _model.MeasurementTable.IsRevStrokeEnabled,
                        FirstMeanAngle_Horizontal = _model.MeasurementTable.FirstMeanAngle_Horizontal,
                        FirstMeanAngle_Vertical = _model.MeasurementTable.FirstMeanAngle_Vertical,
                        LastRelativeAngleToFirstHorizontal = _model.MeasurementTable.LastRelativeAngleToFirstHorizontal,
                        LastRelativeAngleToFirstVertical = _model.MeasurementTable.LastRelativeAngleToFirstVertical,
                        Rows = _model.MeasurementTable.Table
                            .Select(row => new MeasurementRowModelDTO
                            {
                                Position = row.Position,
                                MeasurementLength = row.MeasurementLength,
                                ForwardMinutesHorizontal = row.ForwardMinutesHorizontal,
                                ForwardSecondsHorizontal = row.ForwardSecondsHorizontal,
                                ReverseMinutesHorizontal = row.ReverseMinutesHorizontal,
                                ReverseSecondsHorizontal = row.ReverseSecondsHorizontal,
                                ForwardMinutesVertical = row.ForwardMinutesVertical,
                                ForwardSecondsVertical = row.ForwardSecondsVertical,
                                ReverseMinutesVertical = row.ReverseMinutesVertical,
                                ReverseSecondsVertical = row.ReverseSecondsVertical,
                                FirstMeanAngleHorizontal = row.FirstMeanAngle_Horizontal,
                                FirstMeanAngleVertical = row.FirstMeanAngle_Vertical,
                                LastPointAngleCoeficentHorizontal = row.LastPointAngleCoeficentHorizontal,
                                LastPointAngleCoeficentVertical = row.LastPointAngleCoeficentVertical
                            }).ToList()
                    }
                };

                var options = new JsonSerializerOptions
                    { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.Never };
                string json = JsonSerializer.Serialize(dto, options);
                File.WriteAllText(filePath, json);
                MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    public void LoadFromJson()
    {
        var filePath = GetLoadFileName(FileFormat.JSON);
        if (filePath != string.Empty)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dialogResult = MessageBox.Show("Все текущие данные будут заменены. Продолжить?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult != DialogResult.Yes)
                    return;


                string json = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                CollimatorModelDTO dto = JsonSerializer.Deserialize<CollimatorModelDTO>(json, options);

                // Проверка целостности данных
                if (dto == null)
                {
                    MessageBox.Show("Ошибка: Файл поврежден или имеет неверный формат", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка типа прибора
                if (string.IsNullOrEmpty(dto.DTOTool) || dto.DTOTool != "Autocollimator")
                {
                    MessageBox.Show("Ошибка: Файл не содержит данных для автоколлиматора", "Неверный тип прибора",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка версии данных
                if (_model.ModelVersion != dto.DTOVersion)
                {
                    var versionResult = MessageBox.Show(
                        $"Версия файла ({dto.DTOVersion}) отличается от текущей версии программы ({_model.ModelVersion}).\n" +
                        "Попытаться загрузить данные? Возможна некорректная работа.",
                        "Версия не совпадает",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (versionResult != DialogResult.Yes)
                        return;
                }

                // Проверка обязательных полей
                if (dto.Table == null || dto.Table.Rows == null || !dto.Table.Rows.Any())
                {
                    MessageBox.Show("Ошибка: Файл не содержит данных измерений", "Неполные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Обновляем основную модель
                _model.MeasurementDate = dto.MeasurementDate;
                _model.CollimatorCheckDate = dto.CollimatorCheckDate;
                _model.CollimatorType = dto.CollimatorType;
                _model.ActNumber = dto.ActNumber ?? string.Empty;
                _model.ObjectName = dto.ObjectName ?? string.Empty;
                _model.Description = dto.Description ?? string.Empty;
                _model.WorkerName = dto.WorkerName ?? string.Empty;
                _model.LocalAreaSize = dto.LocalAreaSize;
                _model.HorizontalTolerLocalAreaSize = dto.HorizontalTolerLocalAreaSize;
                _model.HorizontalTolerAllLength = dto.HorizontalTolerAllLength;
                _model.VerticalTolerLocalAreaSize = dto.VerticalTolerLocalAreaSize;
                _model.VerticalTolerAllLength = dto.VerticalTolerAllLength;
                _model.StepSize = dto.StepSize;
                _model.BedLength = dto.BedLength;
                _model.IsRevStrokeEnabled = dto.IsRevstrokeEnabled;
                _model.Plane = dto.Plane;
                _model.IsAdditionsFieldEnabled = dto.IsAddtionsFieldEnabled;

                // Очищаем существующую таблицу
                _model.MeasurementTable.Table.Clear();

                // Восстанавливаем таблицу измерений
                if (dto.Table != null)
                {
                    _model.MeasurementTable.Plane = dto.Table.Plane;
                    _model.MeasurementTable.Step = dto.Table.Step;
                    _model.MeasurementTable.IsRevStrokeEnabled = dto.Table.IsRevStrokeEnabled;

                    // Восстанавливаем строки таблицы
                    MeasurementRowModel previousRow = null;
                    foreach (var rowDto in dto.Table.Rows ?? Enumerable.Empty<MeasurementRowModelDTO>())
                    {
                        var row = new MeasurementRowModel(
                            step: dto.Table.Step,
                            prevRow: previousRow,
                            revStrokeEnable: dto.Table.IsRevStrokeEnabled,
                            isLastRow: false)
                        {
                            Position = rowDto.Position,
                            MeasurementLength = rowDto.MeasurementLength,
                            ForwardMinutesHorizontal = rowDto.ForwardMinutesHorizontal,
                            ForwardSecondsHorizontal = rowDto.ForwardSecondsHorizontal,
                            ReverseMinutesHorizontal = rowDto.ReverseMinutesHorizontal,
                            ReverseSecondsHorizontal = rowDto.ReverseSecondsHorizontal,
                            ForwardMinutesVertical = rowDto.ForwardMinutesVertical,
                            ForwardSecondsVertical = rowDto.ForwardSecondsVertical,
                            ReverseMinutesVertical = rowDto.ReverseMinutesVertical,
                            ReverseSecondsVertical = rowDto.ReverseSecondsVertical,
                            FirstMeanAngle_Horizontal = rowDto.FirstMeanAngleHorizontal,
                            FirstMeanAngle_Vertical = rowDto.FirstMeanAngleVertical,
                            LastPointAngleCoeficentHorizontal = rowDto.LastPointAngleCoeficentHorizontal,
                            LastPointAngleCoeficentVertical = rowDto.LastPointAngleCoeficentVertical
                        };

                        _model.MeasurementTable.Table.Add(row);
                        previousRow = row;
                    }

                    // Восстанавливаем вычисляемые поля таблицы
                    if (_model.MeasurementTable.Table.Count > 1)
                    {
                        _model.MeasurementTable.FirstMeanAngle_Horizontal =
                            _model.MeasurementTable.Table[1].MeanSecondsHorizontal;
                        _model.MeasurementTable.FirstMeanAngle_Vertical =
                            _model.MeasurementTable.Table[1].MeanSecondsVertical;
                    }
                }

                // Пересчитываем все зависимые поля
                _model.MeasurementTable.RecalAllFields();
                _model.UpdateBedLength();

                MessageBox.Show("Данные успешно загружены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Ошибка формата JSON: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }


    private static string GetSaveFileName(FileFormat format)
    {
        var saveFileDialog = new SaveFileDialog();

        switch (format)
        {
            case FileFormat.PDF:
                saveFileDialog.Filter = @"PDF|*.pdf";
                saveFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.JSON:
                saveFileDialog.Filter = @"JDATA|*.jdata";
                saveFileDialog.Title = @"Select JDATA file";
                break;
        }

        saveFileDialog.ShowDialog();

        return saveFileDialog.FileName;
    }

    private static string GetLoadFileName(FileFormat format)
    {
        var loadFileDialog = new OpenFileDialog();

        switch (format)
        {
            case FileFormat.PDF:
                loadFileDialog.Filter = @"PDF|*.pdf";
                loadFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.JSON:
                loadFileDialog.Filter = @"JDATA|*.jdata";
                loadFileDialog.Title = @"Select JDATA file";
                break;
        }

        loadFileDialog.ShowDialog();

        return loadFileDialog.FileName;
    }
}