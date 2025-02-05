using Pryamolineynost;
using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF.Views;

public partial class CollimatorCalibrationDateForm : Form
{
    public event EventHandler ActNumberChanged;
    private CollimatorCalibrationDateController _controller;

    public CollimatorCalibrationDateForm(CollimatorType collimatorType)
    {
        InitializeComponent();
        this.FormClosing += FormClosedOverride;
        _controller = new CollimatorCalibrationDateController(this);
    }

    private void FormClosedOverride(object? sender, FormClosingEventArgs e)
    {
        ExitDialog.ShowDialog(sender, e);
    }

    private void CBActNumber_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void CBActNumber_TextChanged(object sender, EventArgs e)
    {
        ActNumberChanged?.Invoke(this, EventArgs.Empty);
    }
}