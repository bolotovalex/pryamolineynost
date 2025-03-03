using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Models;
using PryamolineynostWF.Views;

namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    private readonly MainCollimatorModel _collimatorModels;
    private CollimatorType _type;
    private CollimatorMainForm _view;
    // private MeasurenmentTableTemplate _dataSet;
    private MeasurementTable _horizontalPlateTable;
    private MeasurementTable _verticalPlateTable;
    private MeasurementTable _table;
    private Plane? _selectedPlane;
    public CollimatorController(CollimatorMainForm view, CollimatorType collimatorType, DateTime date, string actNumber) 
    {
        _type = collimatorType;
        _view = view;
        _view._lblColimmatorType.Text = collimatorType.ToString();
        _view.btnCollimatorTypeChangeClicked += StubFormShow;
        _view.btnGraphicFormClicked += StubFormShow;
        _view.btnLoadChangedClicked += StubFormShow;
        _view.btnSaveChangedClicked += StubFormShow;
        _view.btnPdfFormClicked += StubFormShow;
        _view.btnShowDataFormClicked += BtnOpenMeasurementForm_click;
        CreateTables();
        _selectedPlane = Plane.Horizontal;
    }

    private void StubFormShow(object sender, EventArgs e)
    {
        //TODO Реализовать
        var stubForm = new StubDialog("Не реализовано");
        stubForm.ShowDialog();
        stubForm.Dispose();
    }
    
    
    private void BtnOpenMeasurementForm_click(object sender, EventArgs e)
    {
        var measurementForm = new MeasurementForm(_table, _selectedPlane);
        measurementForm.Show();
    }

    private void CreateTables()
    {
        _verticalPlateTable = MeasurementTableTepmplate.GetTable("Вертикальная поверхность");
        _table = _verticalPlateTable;

    }
}