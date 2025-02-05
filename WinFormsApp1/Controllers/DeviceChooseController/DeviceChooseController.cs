using Pryamolineynost;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _view.collimatorModelComboBox.Enabled = true;
                _view.collimatorModelText.Enabled = true;
            }
            else
            {
                _view.collimatorModelComboBox.Enabled = false;
                _view.collimatorModelText.Enabled = false;
            }
        }

        private void OnBtnOkClicked(object sender, EventArgs e)
        {
            var selectedDevice = (MeasurementDevices)_view.SelectedDevice;
            _view.Hide();

            if (selectedDevice == MeasurementDevices.Level)
                OpenLevelForm();
            else if (selectedDevice == MeasurementDevices.Collimator)
                OpenCollimatorForm();
        }

        private void OnBtnLoadClicked(object sender, EventArgs e)
        {

        }

        private void OnBtnCancelClicked(object sender, EventArgs e)
        {

        }

        private void OpenLevelForm()
        {
            using (var levelForm = new LevelMainForm())
            {
                levelForm.ShowDialog();
            }
            _view.Close();
        }

        private void OpenCollimatorForm()
        {
            //using (var collimatorForm = new CollimatorCalibrationDateForm((CollimatorType)_view.SelectedCollimator))
            //{
            //    collimatorForm.ShowDialog();
            //}
            //_view.Hide();
        }

        
    }
}
