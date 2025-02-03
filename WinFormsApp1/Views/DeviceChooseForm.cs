using Pryamolineynost;
using PryamolineynostWF.Controllers.DeviceChooseController;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF.Views;

public partial class DeviceChooseForm : Form
{
    private Thread secondThread;
    public event EventHandler OkButtonClicked;
    public event EventHandler CancelButtonClicked;
    public event EventHandler MeasurementDeviceSelect;
    
    
    public MeasurementDevices SelectedDevice => (MeasurementDevices)deviceComboBox.SelectedValue;
    public CollimatorType SelectedCollimator => (CollimatorType)collimatorModelComboBox.SelectedValue;
    private DeviceChooseController _controller;

    public DeviceChooseForm()
    {

        InitializeComponent();
        _controller = new DeviceChooseController(this);
    }

    private void ToogleCollimatorTypeElements()
    {
        MeasurementDeviceSelect?.Invoke(this, EventArgs.Empty);
    }
    

    //private void cancelButton_Click(object sender, EventArgs e)
    //{
    //    Close();
    //}

    private void okButton_Click(object sender, EventArgs e)
    {
        OkButtonClicked?.Invoke(this, EventArgs.Empty);
    }

    private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ToogleCollimatorTypeElements();
    }

    private void collimatorModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}