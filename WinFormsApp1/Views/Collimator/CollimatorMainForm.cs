using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Interfaces;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Views.Collimator;

public partial class CollimatorMainForm : Form, ICollimatorView
{
    private readonly CollimatorController _controller;
    private CollimatorType _collimatorType;
    
    
    public CollimatorMainForm(CollimatorType collimatorType)
    {
        _collimatorType = collimatorType;
        _controller = new CollimatorController(this, _collimatorType);
        InitializeComponent();
    }
}