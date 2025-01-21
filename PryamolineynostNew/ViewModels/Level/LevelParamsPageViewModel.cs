using System;
using System.Windows.Input;
using PryamolineynostNew.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.NotUse;

namespace PryamolineynostNew.ViewModels;

public partial class LevelParamsPageViewModel : PageViewModelBase
{
    [ObservableProperty] private DateTimeOffset _date;
    [ObservableProperty] private string _projectName;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _author;
    [ObservableProperty] private decimal _maxDeviation;
    [ObservableProperty] private decimal _minDeviation;
    [ObservableProperty] private decimal _verticalDeviation;
    [ObservableProperty] private decimal _localAreaDeviation;
    [ObservableProperty] private int _bedLength;
    [ObservableProperty] private int _localAreaLength;
    [ObservableProperty] private int _localAreaTolerance;
    [ObservableProperty] private int _allLengthTolerance;
    [ObservableProperty] private int _step;
    [ObservableProperty] private Level _model;
    [ObservableProperty] private bool _canApplyChanges;
    [ObservableProperty] private bool _canCancelChanges;


    private void InitializeProperties()
    {
        CanApplyChanges = false;
        CanCancelChanges = false;
    }

    private void EvaluateChanges()
    {
        // Сравниваем текущие значения с оригинальными из модели
        CanApplyChanges = !(
            Model.Name == ProjectName &&
            Model.Description == Description &&
            Model.Fio == Author &&
            Model.LocalAreaLength == LocalAreaLength &&
            Model.MeterTolerance == LocalAreaTolerance &&
            Model.FullTolerance == AllLengthTolerance &&
            Model.Step == Step
        );

        CanCancelChanges = CanApplyChanges; // Если есть изменения, активна и кнопка отмены
    }

    public LevelParamsPageViewModel(Level model)
    {
        Model = model;
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
        Step = Model.Step;
        LocalAreaLength = Model.LocalAreaLength;
        AllLengthTolerance = Model.FullTolerance;
        InitializeProperties();
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
        AllLengthTolerance = Model.FullTolerance;
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
    }


    partial void OnDateChanged(DateTimeOffset date)
    {
        EvaluateChanges();
    }

    partial void OnProjectNameChanged(string value)
    {
        EvaluateChanges();
    }

    partial void OnDescriptionChanged(string value)
    {
        EvaluateChanges();
    }

    partial void OnAuthorChanged(string value)
    {
        EvaluateChanges();
    }

    partial void OnBedLengthChanged(int value)
    {
    }

    partial void OnLocalAreaLengthChanged(int value)
    {
        EvaluateChanges();
    }

    partial void OnLocalAreaToleranceChanged(int value)
    {
        EvaluateChanges();
    }

    partial void OnAllLengthToleranceChanged(int value)
    {
        EvaluateChanges();
    }

    partial void OnStepChanged(int value)
    {
        EvaluateChanges();
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
}