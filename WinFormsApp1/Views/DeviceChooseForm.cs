using Pryamolineynost;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF.Views;

public partial class DeviceChooseForm : Form
{
    private Thread secondThread;

    public DeviceChooseForm()
    {
        InitializeComponent();
        FillDeviceTypeComboBox();
        FillCollimatorTypeComboBox();
        ToogleCollimatorTypeElements();
    }

    private void FillDeviceTypeComboBox()
    {
        deviceComboBox.DataSource = Enum.GetValues(typeof(MeasurementDevices));
    }

    private void FillCollimatorTypeComboBox()
    {
        collimatorModelComboBox.DataSource = Enum.GetValues(typeof(CollimatorType));
    }

    private void ToogleCollimatorTypeElements()
    {
        if ((MeasurementDevices)deviceComboBox.SelectedValue == MeasurementDevices.Collimator)
        {
            collimatorModelComboBox.Enabled = true; 
            collimatorModelText.Enabled = true;
        }
        else
        {
            collimatorModelComboBox.Enabled = false;
            collimatorModelText.Enabled = false;
        }
    }

    private void startLevelForm()
    {
        Application.Run(new LevelMainForm());
    }
    
    private void startCollimatorForm()
    {
        Application.Run(new CollimatorMainForm((CollimatorType)collimatorModelComboBox.SelectedValue));
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        if ((MeasurementDevices)deviceComboBox.SelectedValue == MeasurementDevices.Level)
        {
            secondThread = new Thread(startLevelForm);
            secondThread.SetApartmentState(ApartmentState.STA);
            secondThread.Start();
        }
        else if ((MeasurementDevices)deviceComboBox.SelectedValue == MeasurementDevices.Collimator)
        {
            secondThread = new Thread(startCollimatorForm);
            secondThread.SetApartmentState(ApartmentState.STA);
            secondThread.Start();
        }
        this.Close();
    }

    private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ToogleCollimatorTypeElements();
    }

    private void collimatorModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}