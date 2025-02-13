using PryamolineynostWF.Enums;
using PryamolineynostWF.Interfaces;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController
{
    private readonly CollimatorModels _models;
    private CollimatorType _type;
    private CollimatorMainForm _view;

    public CollimatorController(CollimatorMainForm view, CollimatorType collimatorType, DateTime date, string actNumber) 
    {
        _type = collimatorType;
        _view = view;
        _view.labelCollimatorType.Text = collimatorType.ToString();
    }

}