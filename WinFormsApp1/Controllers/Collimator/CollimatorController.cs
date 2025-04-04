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
        _view.btnSaveChangedClicked += (Sender, e) => SaveToJson("collimator_data.json");
        _view.btnLoadChangedClicked += (Sender, e) => LoadFromJson("collimator_data.json");
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

    public void SaveToJson(string filePath)
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
                            ReverseSecondsHorizontal = row.ReverseSecondsVertical,
                            FirstMeanAngleHorizontal = row.FirstMeanAngle_Horizontal,
                            FirstMeanAngleVertical = row.FirstMeanAngle_Vertical,
                            LastPointAngleCoeficentHorizontal = row.LastPointAngleCoeficentHorizontal,
                            LastPointAngleCoeficentVertical = row.LastPointAngleCoeficentVertical
                        }).ToList()
                }
            };

            var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.Never };
            string json = JsonSerializer.Serialize(dto, options);
            File.WriteAllText(filePath, json);
            MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}