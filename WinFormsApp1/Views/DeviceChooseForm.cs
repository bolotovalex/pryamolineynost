using LogicLibrary;
using Pryamolineynost;
using PryamolineynostWF.Controllers;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Views;

public partial class DeviceChooseForm : Form
{
    public event EventHandler OkClicked;
    public event EventHandler CancelClicked;
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
        //    .Cast<MeasurementDevices>()
        //    .Select(d => new { Value = d, Display = DeviceTypeTranslation.GetTranslation[d] })
        //    .ToList();
        //deviceComboBox.DisplayMember = "Display";
        //deviceComboBox.ValueMember = "Value";
    }

    private void FillCollimatorTypeComboBox()
    {
        collimatorModelComboBox.DataSource = Enum.GetValues(typeof(CollimatorType));
        //    .Cast<CollimatorType>()
        //    .Select(d => new { Value = d, Display = CollimatorTypeTranslation.GetTranslation[d] })
        //    .ToList();
        //collimatorModelComboBox.DisplayMember = "Display";
        //collimatorModelComboBox.ValueMember = "Value";
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
        Application.Run(new MainForm());
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        if ((MeasurementDevices)deviceComboBox.SelectedValue == MeasurementDevices.Level)
        {
            this.Close();
            secondThread = new Thread(startLevelForm);
            secondThread.SetApartmentState(ApartmentState.STA);
            secondThread.Start();
        }
        
    }

    private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ToogleCollimatorTypeElements();
    }

    private void collimatorModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}