using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Interfaces;

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
        labelCollimatorType.Text = collimatorType.ToString();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {

    }
}