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
        _table = new MeasurementTable("Горизонтальная плоскость");
        _table.AddColumn("interval","Проверяемый интервал, мм", typeof(int));
        _table.AddColumn("fDegree","Пр.° ", typeof(int));
        _table.AddColumn("fMinutes","Пр.'", typeof(int));
        _table.AddColumn("fSeconds","Пр.\"", typeof(decimal));
        _table.AddColumn("rDegree","Обр.° ", typeof(int));
        _table.AddColumn("rMinutes","Обр.'", typeof(int));
        _table.AddColumn("rSeconds","Обр.\"", typeof(decimal));
        _table.AddColumn("mean","Среднее значение", typeof(string));
        _table.AddColumn("bi","βi, угл. с", typeof(string));
        _table.AddColumn("hi","hi, мкм", typeof(string));
        _table.AddColumn("Ai","Ai, мкм", typeof(string));
        _table.AddColumn("Bi","Bi, мкм", typeof(string));
        _table.AddColumn("Hi","Hi, мкм", typeof(string));
        _table.AddRow(0,0,0,0,0,0,0,0,0,0,0,0,0);
        _table.AddRow(0,0,0,0,0,0,0,0,0,0,0,0,0);
        // _dataSet = new DataSet();
        // var mainTable = new DataTable("Таблица объединения");
        // mainTable.Columns.Add("Id", typeof(int));
        // mainTable.Columns.Add("Interval", typeof(int));
        // mainTable.PrimaryKey = new DataColumn[] { mainTable.Columns["Id"] };
        // _dataSet.Tables.Add(mainTable);
        // mainTable.Rows.Add(0, 0);
        // mainTable.Rows.Add(1, 1);
        //
        // var horizontalSurfaceTable = new DimensionTable("Горизонтальная поверхность");
        //
        // _dataSet.Tables.Add(horizontalSurfaceTable);
        // var horizontaRelaion = new DataRelation("HorizontalRelation", mainTable.Columns["Interval"], horizontalSurfaceTable.Columns["Interval"]);
        // _dataSet.Relations.Add(horizontaRelaion);
        // horizontalSurfaceTable.Rows.Add(0, 0, 0, 0, 0, 0);
        // horizontalSurfaceTable.Rows.Add(0, 0, 0, 0, 0, 0);
        // horizontalSurfaceTable.Rows.Add(0, 0, 0, 0, 0, 0);
        //
        // var verticalSurfaceTable = new DimensionTable("Вертикальная поверхность");
        // verticalSurfaceTable.Rows.Add(0, 0, 0, 0, 0, 0);
        // _dataSet.Tables.Add(verticalSurfaceTable);
        // var verticalRelation = new DataRelation("VerticalRealtion", mainTable.Columns["Interval"], verticalSurfaceTable.Columns["Interval"]);
        // _dataSet.Relations.Add(verticalRelation);

    }
}