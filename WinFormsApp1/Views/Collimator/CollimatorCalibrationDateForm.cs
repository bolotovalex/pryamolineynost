using Pryamolineynost;
using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF.Views;

public partial class CollimatorCalibrationDateForm : Form
{
    public event EventHandler ActNumberChanged;
    public event EventHandler BtnOkClicked;
    public event EventHandler BtnPrevClicked;
    private CollimatorCalibrationDateController _controller;

    public CollimatorCalibrationDateForm(CollimatorType collimatorType)
    {
        InitializeComponent();
        this.FormClosing += FormClosedOverride;
        _controller = new CollimatorCalibrationDateController(this, collimatorType);
    }

    private void FormClosedOverride(object? sender, FormClosingEventArgs e)
    {
        ExitDialog.ShowDialog(sender, e);
    }

    private void TbActNumber_TextChanged(object sender, EventArgs e)
    {
        ActNumberChanged?.Invoke(this, EventArgs.Empty);
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        BtnOkClicked?.Invoke(this, EventArgs.Empty);
    }
    private void BtnPrev_Click(object sender, EventArgs e)
    {
        BtnPrevClicked?.Invoke(this, EventArgs.Empty);
    }
}