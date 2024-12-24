using System;
using System.Windows.Input;
using PryamolineynostNew.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.LevelTool;

namespace PryamolineynostNew.ViewModels
{
    public partial class LevelParamsPageViewModel : PageViewModelBase
    {
        [ObservableProperty]
        private DateTimeOffset _date;
        [ObservableProperty]
        private string _projectName;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private string _author;
        [ObservableProperty]
        private decimal _maxDeviation;
        [ObservableProperty]
        private decimal _minDeviation;
        [ObservableProperty]
        private decimal _verticalDeviation;
        [ObservableProperty]
        private decimal _localAreaDeviation;
        [ObservableProperty]
        private int _bedLength;
        [ObservableProperty]
        private int _localAreaLength;
        [ObservableProperty]
        private int _localAreaTolerance;
        [ObservableProperty]
        private int _allLengthTolerance;
        [ObservableProperty]
        private int _step;

        private Level _model = new Level();
        

        public LevelParamsPageViewModel()
        {
            if (_model != null)
            {
                Date = DateTimeOffset.Now;
                ProjectName = _model.Name;
                Description = _model.Description;
                Author = _model.Fio;
                MaxDeviation = _model.GetMaxDeviation();
                MinDeviation = _model.GetMinDeviation();
                VerticalDeviation = _model.GetVerticalDeflection();
                //LocalAreaDeviation = _model.GetLocalAreaDeviation();
                BedLength = _model.GetBedAreaLength();
                //LocalAreaLength = _model.GetLocalAreaLength();
                //LocalAreaTolerance = _model.GetLocalAreaTolerance();
                //AllLengthTolerance = _model.GetAllLengthTolerance();
                Step = _model.Step;
            }
        }
        
        [RelayCommand]
        private void ApplyButtonClicked()
        {
            
        }

        [RelayCommand]
        private void CancelButtonClicked()
        {
            
        }

        partial void OnDateChanged(DateTimeOffset date)
        {
            Date = date;
        }
        partial void OnProjectNameChanged(string value)
        {
            // ProjectName = value;
        }

        partial void OnDescriptionChanged(string value)
        {
            // Description = value;
        }

        partial void OnAuthorChanged(string value)
        {
            // Author = value;
        }

        partial void OnBedLengthChanged(int value)
        {
            // BedLength = value;
        }

        partial void OnLocalAreaLengthChanged(int value)
        {
            // LocalAreaLength = value;
        }

        partial void OnLocalAreaToleranceChanged(int value)
        {
            // LocalAreaTolerance = value;
        }

        partial void OnAllLengthToleranceChanged(int value)
        {
            // AllLengthTolerance = value;
        }

        partial void OnStepChanged(int value)
        {
            // Step = value;
        }

        partial void OnMaxDeviationChanged(decimal value)
        {
            // MaxDeviation = value;
        }

        partial void OnMinDeviationChanged(decimal value)
        {
            // MinDeviation = value;
        }

        partial void OnVerticalDeviationChanged(decimal value)
        {
            // VerticalDeviation = value;
        }

        partial void OnLocalAreaDeviationChanged(decimal value)
        {
            // LocalAreaDeviation = value;
        }
        
        
        
        private void UpdateProjectName()
        {
        }
    }
}
