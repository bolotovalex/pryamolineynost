using PryamolineynostWF.Enums;
using PryamolineynostWF.Interfaces;
using PryamolineynostWF.Models.Collimator;
namespace PryamolineynostWF.Controllers.Collimator;

public class CollimatorController(ICollimatorView view, CollimatorType collimatorType, DateTime date, string actNumber)
    
{
    private readonly CollimatorModels _models;
}