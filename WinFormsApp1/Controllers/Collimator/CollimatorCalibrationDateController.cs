using PryamolineynostWF.Services;
using PryamolineynostWF.Views;

namespace PryamolineynostWF.Controllers.Collimator
{
    public class CollimatorCalibrationDateController
    {
        private readonly CollimatorCalibrationDateForm _view;
        public CollimatorCalibrationDateController(CollimatorCalibrationDateForm view) 
        {
            _view = view;
            _view.ActNumberChanged += ActNmberTextChanged;
            ComboBoxValidator.InitializeValidation(_view);
            _view.OkButton.Enabled = false;
        }

        private void ActNmberTextChanged(object? sender, EventArgs e)
        {
            _view.OkButton.Enabled = ComboBoxValidator.CheckComboBoxIsFilled(_view.CBActNumber);
        }
    }
}
