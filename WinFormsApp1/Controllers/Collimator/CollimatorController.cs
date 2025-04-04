using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PryamolineynostWF.DTO.Collimator;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    public CollimatorForm _view { get; init; }
    private CollimatorModel _model;


    public
        CollimatorController(CollimatorType collimatorType, DateTime date, string actNumber)
    {
        _model = new CollimatorModel();
        _view = new CollimatorForm(collimatorType, date, actNumber);


        Initialization(collimatorType, date, actNumber);
        BindingTextBoxData();
        BindinLabelData();
        BindButtonActions();

        _view.Show();
    }

    //public Form View() => _view;
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
        _view.GetDateTimeControl.DataBindings.Add("Value", _model, "MeasurementDate", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbObjectName.DataBindings.Add("Text", _model, "ObjectName", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbDescription.DataBindings.Add("Text", _model, "Description", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbWorkerName.DataBindings.Add("Text", _model, "WorkerName", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbLocalAreaSize.DataBindings.Add("Text", _model, "LocalAreaSize", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbHorizontalTolerLocalAreaSize.DataBindings.Add("Text", _model, "HorizontalTolerLocalAreaSize", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbHorizontalTolerAllLength.DataBindings.Add("Text", _model, "HorizontalTolerAllLength", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbVerticalTolerLocalAreaSize.DataBindings.Add("Text", _model, "VerticalTolerLocalAreaSize", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbVerticalTolerAllLength.DataBindings.Add("Text", _model, "VerticalTolerAllLength", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetTbStepSize.DataBindings.Add("Text", _model, "StepSize", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void BindinLabelData()
    {
        _view.GetLblColimmatorType.DataBindings.Add("Text", _model, "CollimatorType", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblBedLength.DataBindings.Add("Text", _model, "BedLength", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblHorizontalMaxDeviation.DataBindings.Add("Text", _model, "HorizontalMaxDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblVerticalMaxDeviation.DataBindings.Add("Text", _model, "VerticalMaxDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblHorizontalMinDeviation.DataBindings.Add("Text", _model, "HorizontalMinDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblVericalMinDeviation.DataBindings.Add("Text", _model, "VerticalMinDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblHorizontalMeanDeviation.DataBindings.Add("Text", _model, "HorizontalMeanDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblVerticalMeanDeviation.DataBindings.Add("Text", _model, "VerticalMeanDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblHorizontalLineDeviation.DataBindings.Add("Text", _model, "HorizontalAreaDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
        _view.GetLblVerticalLineDeviation.DataBindings.Add("Text", _model, "VerticalAreaDeviation", true,
            DataSourceUpdateMode.OnPropertyChanged);
    }

    private void BindButtonActions()
    {
        _view.btnShowDataFormClicked += ShowMeasurementForm;
        _view.btnGraphicFormClicked += StubFormShow;
        _view.btnPdfFormClicked += StubFormShow;
        _view.btnExitClicked += StubFormShow;
        _view.btnSaveChangedClicked += (Sender, e) => SaveToJson();
        _view.btnLoadChangedClicked += (Sender, e) => LoadFromJson();
        _view.btnCollimatorTypeChangeClicked += StubFormShow;
    }


    private void ShowMeasurementForm(object sender, EventArgs e)
    {
        var measurementController = new MeasurementTableController(_model);
        measurementController.ShowForm();
    }

    public void SwitchPlane(Plane plane)
    {
        _view.SwitchPlane(plane);
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
                    PropertyNameCaseInsensitive = true // Для обработки разного регистра свойств
                };

                var dto = JsonSerializer.Deserialize<CollimatorModelDTO>(json, options);

                if (dto == null)
                {
                    MessageBox.Show("Не удалось прочитать файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (dto.Version != CurrentDataVersion)
                //{
                //    MessageBox.Show("Файл создан в другой версии программы", "Предупреждение",
                //                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

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


    private string GetSaveFileName(FileFormat format)
    {
        var saveFileDialog = new SaveFileDialog();

        switch (format)
        {
            case FileFormat.PDF:
                saveFileDialog.Filter = @"PDF|*.pdf";
                saveFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.JSON:
                saveFileDialog.Filter = @"JSON|*.json";
                saveFileDialog.Title = @"Select JSON file";
                break;
        }

        saveFileDialog.ShowDialog();

        return saveFileDialog.FileName;
    }

    private string GetLoadFileName(FileFormat format)
    {
        var loadFileDialog = new OpenFileDialog();

        switch (format)
        {
            case FileFormat.PDF:
                loadFileDialog.Filter = @"PDF|*.pdf";
                loadFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.JSON:
                loadFileDialog.Filter = @"JSON|*.json";
                loadFileDialog.Title = @"Select JSON file";
                break;
        }

        loadFileDialog.ShowDialog();

        return loadFileDialog.FileName;
    }
}