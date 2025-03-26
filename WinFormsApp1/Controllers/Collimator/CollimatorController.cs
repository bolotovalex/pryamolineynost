using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        //Заглушка
        var stubForm = new StubDialog("Не реализовано");
        stubForm.ShowDialog();
        stubForm.Dispose();
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
        _view.btnSaveChangedClicked += StubFormShow;
        _view.btnLoadChangedClicked += StubFormShow;
        _view.btnCollimatorTypeChangeClicked += StubFormShow;
    }


    private void ShowMeasurementForm(object sender, EventArgs e)
    {
        var measurementController = new MeasurementTableController(_model);
        measurementController.ShowForm();
    }

    
}