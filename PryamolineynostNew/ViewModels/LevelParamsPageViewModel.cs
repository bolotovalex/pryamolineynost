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
        [ObservableProperty]
        private Level _model;
        

        public LevelParamsPageViewModel(Level model)
        {
            Model = model;
            // UpdateFields();
            Date = DateTimeOffset.Now;
            ProjectName = Model.Name;
            Description = Model.Description;
            Author = Model.Fio;
            MaxDeviation = Model.GetMaxDeviation();
            MinDeviation = Model.GetMinDeviation();
            VerticalDeviation = Model.GetVerticalDeflection();
            LocalAreaDeviation = Model.GetAreaDeflection();
            BedLength = Model.GetBedAreaLength();
            LocalAreaLength = Model.LocalAreaLength;
            //LocalAreaTolerance = _model.GetLocalAreaTolerance();
            //AllLengthTolerance = _model.GetAllLengthTolerance();
            Step = Model.Step;
        }
        
        [RelayCommand]
        private void ApplyButtonClicked()
        {
            Model.Name = ProjectName;
            Model.Description = Description;
            Model.Fio = Author;
            Model.LocalAreaLength = LocalAreaLength;
            Model.MeterTolerance = LocalAreaTolerance;
            Model.FullTolerance = AllLengthTolerance;
            Model.Step = Step;
            Model.UpdateAllRows(Model.currUnit);
            BedLength = Model.GetBedAreaLength();
            MinDeviation = Model.GetMinDeviation();
            MaxDeviation = Model.GetMaxDeviation();
            VerticalDeviation = Model.GetVerticalDeflection();
            LocalAreaLength = Model.LocalAreaLength;
            // LocalAreaDeviation = Model.GetLocalAreaDeviation();
            
        }

        [RelayCommand]
        private void CancelButtonClicked()
        {
            ProjectName = Model.Name;
            Description = Model.Description;
            Author = Model.Fio;
            LocalAreaLength = Model.LocalAreaLength;
            LocalAreaTolerance = Model.MeterTolerance;
            AllLengthTolerance = Model.FullTolerance;
            Step = Model.Step;
            BedLength = Model.GetBedAreaLength();
            MinDeviation = Model.GetMinDeviation();
            MaxDeviation = Model.GetMaxDeviation();
            VerticalDeviation = Model.GetVerticalDeflection();
            // LocalAreaDeviation = Model.GetLocalAreaDeviation();
        }

        partial void OnDateChanged(DateTimeOffset date)
        {
            // Date = date;
            
        }
        partial void OnProjectNameChanged(string value)
        {
            // ProjectName = value;
        }

        partial void OnDescriptionChanged(string value)
        {
            Description = value;
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
