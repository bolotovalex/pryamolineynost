using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Interfaces;
using PryamolineynostWF.Models.Collimator;

namespace PryamolineynostWF.Views.Collimator;

public partial class CollimatorMainForm : Form, ICollimatorView
{
    private readonly CollimatorController _controller;
    private CollimatorType _collimatorType;
    private DateOnly _inspectionDate;
    private string _actNumber;
    
    
    public CollimatorMainForm(CollimatorType collimatorType, DateTime date, string actNumber)
    {
        InitializeComponent();
        _controller = new CollimatorController(this, collimatorType, date, actNumber);


        //_collimatorType = collimatorType;
        //_inspectionDate = date;
        //_actNumber = actNumber;
        //_controller = new CollimatorController(this, _collimatorType);
    }
}