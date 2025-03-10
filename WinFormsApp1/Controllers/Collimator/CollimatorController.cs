using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Views;

namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    public CollimatorForm mainForm { get; set; }
    private CollimatorModel _model;

    
    public CollimatorController(CollimatorType collimatorType, DateTime date, string actNumber) 
    {
        var _model = new CollimatorModel();
        mainForm = new CollimatorForm(collimatorType, date, actNumber);
        mainForm.Show();
    }


    private void StubFormShow(object sender, EventArgs e)
    {
        //Заглушка
        var stubForm = new StubDialog("Не реализовано");
        stubForm.ShowDialog();
        stubForm.Dispose();
    }
    
}