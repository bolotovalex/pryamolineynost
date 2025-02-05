using Pryamolineynost;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF.Views;

public partial class CollimatorCalibrationDateForm : Form
{
    private Thread secondThread;

    public CollimatorCalibrationDateForm(CollimatorType collimatorType)
    {
        InitializeComponent();
    }

    

}