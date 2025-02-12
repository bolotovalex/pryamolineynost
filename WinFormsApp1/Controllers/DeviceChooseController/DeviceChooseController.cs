using Pryamolineynost;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;
using PryamolineynostWF.Views;

namespace PryamolineynostWF.Controllers.DeviceChooseController
{
    public class DeviceChooseController
    {
        private readonly DeviceChooseForm _view;

        public DeviceChooseController(DeviceChooseForm view)
        {
            _view = view;
            _view.BtnOkClicked += OnBtnOkClicked;
            _view.BtnLoadClicked += OnBtnLoadClicked;
            _view.BtnCancelClicked += OnBtnCancelClicked;
            _view.MeasurementDeviceSelect += MeasurementDeviceToolge;
            _view.deviceComboBox.DataSource = Enum.GetValues(typeof(MeasurementDevices));
            _view.collimatorModelComboBox.DataSource = Enum.GetValues(typeof(CollimatorType));
        }

        private void MeasurementDeviceToolge(object sender, EventArgs e)
        {
            if ((MeasurementDevices)_view.deviceComboBox.SelectedValue == MeasurementDevices.Collimator)
            {
                _view.collimatorModelComboBox.Show();
                _view.collimatorModelText.Enabled = true;
            }
            else
            {
                _view.collimatorModelComboBox.Hide();
                _view.collimatorModelText.Enabled = false;
            }
        }

        private void OnBtnOkClicked(object sender, EventArgs e)
        {
            var selectedDevice = (MeasurementDevices)_view.SelectedDevice;

            if (selectedDevice == MeasurementDevices.Level)
            {
                var levelForm = new LevelMainForm();
                NavigationStack.Navigate(_view, levelForm);
            }
                
            else if (selectedDevice == MeasurementDevices.Collimator)
            {
                var collimatorDateChooseForm = new CollimatorCalibrationDateForm((CollimatorType)_view.SelectedCollimator);
                NavigationStack.Navigate(_view, collimatorDateChooseForm);
            }
                
        }

        private void OnBtnLoadClicked(object sender, EventArgs e)
        {
            using (var stubDialog = new StubDialog("Пока не реализовано"))
            {
                stubDialog.ShowDialog();
            }
        }

        private void OnBtnCancelClicked(object sender, EventArgs e)
        {
            _view.Close();
        }
    }
}
