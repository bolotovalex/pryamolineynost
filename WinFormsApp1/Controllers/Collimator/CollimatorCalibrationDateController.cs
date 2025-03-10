using Pryamolineynost;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;
using PryamolineynostWF.Views;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF.Controllers.Collimator
{
    public class CollimatorCalibrationDateController
    {
        private readonly CollimatorCalibrationDateForm _view;
        private CollimatorMainForm _mainForm;
        private CollimatorType _selectedCollimatorType;
        public CollimatorCalibrationDateController(CollimatorCalibrationDateForm view, CollimatorType selectedCollimatorType) 
        {
            _view = view;
            _selectedCollimatorType = selectedCollimatorType;
            _view.ActNumberChanged += ActNmberTextChanged;
            FieldValidator.InitializeValidation(_view);
            _view.OkButton.Enabled = false;
            _view.BtnOkClicked += BtnOkClicked;
            _view.BtnPrevClicked += BtnPrevClicked;
        }

        
        private void ActNmberTextChanged(object? sender, EventArgs e)
        {
            _view.OkButton.Enabled = FieldValidator.TextBoxIsFilledCheck(_view.tbActNumber);
        }

        private void BtnOkClicked(object sender, EventArgs e) 
        {
            var collimatorController = new CollimatorController(_selectedCollimatorType, _view.dateTimePicker1.Value, _view.tbActNumber.Text);
            NavigationStack.Clear(); //TODO Пока костыль
            NavigationStack.Navigate(_view, collimatorController.mainForm);
        }

        private void BtnPrevClicked(object sender, EventArgs e)
        {
            using (var stubDialog = new StubDialog("Пока не реализовано"))
            {
                stubDialog.ShowDialog();
            }
        }


    }
}
