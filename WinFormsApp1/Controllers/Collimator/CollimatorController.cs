using PryamolineynostWF.Enums;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Views;

namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    public CollimatorMainForm mainForm { get; set; }
    
    public CollimatorController(CollimatorType collimatorType, DateTime date, string actNumber) 
    {
        
        mainForm = new CollimatorMainForm(collimatorType, date, actNumber);
    }

    
    public void ShowMainForm(CollimatorType collimatorType, DateTime date, string actNumber)
    {
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