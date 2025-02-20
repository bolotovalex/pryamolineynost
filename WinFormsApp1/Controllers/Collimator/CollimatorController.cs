using PryamolineynostWF.Enums;
using PryamolineynostWF.Interfaces;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using System.Data;
namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    private readonly MainCollimatorModel _collimatorModels;
    private CollimatorType _type;
    private CollimatorMainForm _view;
    private DataSet _dataSet;

    public CollimatorController(CollimatorMainForm view, CollimatorType collimatorType, DateTime date, string actNumber) 
    {
        _type = collimatorType;
        _view = view;
        _view._lblColimmatorType.Text = collimatorType.ToString();
        CreateTables();
    }



    private void BtnOpenMeasurementForm_click(object sender, EventArgs e)
    {
        var measurementForm = new MeasurementForm(_dataSet);
        measurementForm.Show();
    }

    private void CreateTables()
    {
        _dataSet = new DataSet();
        var mainTable = new DataTable("Таблица объединения");
        mainTable.Columns.Add("Id", typeof(int));
        mainTable.Columns.Add("Interval", typeof(int));
        mainTable.PrimaryKey = new DataColumn[] { mainTable.Columns["Id"] };
        _dataSet.Tables.Add(mainTable);
        mainTable.Rows.Add(0, 0);
        mainTable.Rows.Add(1, 1);

        var horizontalSurfaceTable = new DimensionTable("Горизонтальная поверхность");
        
        _dataSet.Tables.Add(horizontalSurfaceTable);
        var horizontaRelaion = new DataRelation("HorizontalRelation", mainTable.Columns["Interval"], horizontalSurfaceTable.Columns["Interval"]);
        _dataSet.Relations.Add(horizontaRelaion);
        horizontalSurfaceTable.Rows.Add(0, 0, 0, 0, 0, 0);

        var verticalSurfaceTable = new DimensionTable("Вертикальная поверхность");
        verticalSurfaceTable.Rows.Add(0, 0, 0, 0, 0, 0);
        _dataSet.Tables.Add(verticalSurfaceTable);
        var verticalRelation = new DataRelation("VerticalRealtion", mainTable.Columns["Interval"], verticalSurfaceTable.Columns["Interval"]);
        _dataSet.Relations.Add(verticalRelation);
    }
}