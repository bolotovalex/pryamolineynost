using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    public CollimatorForm view { get; set; }
    private CollimatorModel _model;

    
    public CollimatorController(CollimatorType collimatorType, DateTime date, string actNumber) 
    {
        var _model = new CollimatorModel();
        view = new CollimatorForm(collimatorType, date, actNumber);
        view.tpDate.DataBindings.Add("Value", _model, "MeasurementDate", true, DataSourceUpdateMode.OnPropertyChanged);
        view.Show();
    }


    private void StubFormShow(object sender, EventArgs e)
    {
        //Заглушка
        var stubForm = new StubDialog("Не реализовано");
        stubForm.ShowDialog();
        stubForm.Dispose();
    }
    
}