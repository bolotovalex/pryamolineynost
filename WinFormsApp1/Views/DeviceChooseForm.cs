using PryamolineynostWF.Controllers.DeviceChooseController;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;

namespace PryamolineynostWF.Views;

public partial class DeviceChooseForm : Form
{
    private Thread secondThread;
    public event EventHandler BtnOkClicked;
    public event EventHandler BtnCancelClicked;
    public event EventHandler BtnLoadClicked;
    public event EventHandler MeasurementDeviceSelect;


    public MeasurementDevices SelectedDevice => (MeasurementDevices)deviceComboBox.SelectedValue;
    public CollimatorType SelectedCollimator => (CollimatorType)collimatorModelComboBox.SelectedValue;

    private DeviceChooseController _controller;

    public DeviceChooseForm()
    {
        InitializeComponent();
        _controller = new DeviceChooseController(this);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        BtnOkClicked?.Invoke(this, EventArgs.Empty);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        BtnCancelClicked?.Invoke(this, EventArgs.Empty);
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        BtnLoadClicked?.Invoke(this, EventArgs.Empty);
    }

    private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        MeasurementDeviceSelect?.Invoke(this, EventArgs.Empty);
    }

    private void collimatorModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}