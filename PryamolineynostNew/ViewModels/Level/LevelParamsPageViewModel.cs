using System;
using System.ComponentModel.DataAnnotations;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.LevelTool;


namespace PryamolineynostNew.ViewModels;

public partial class LevelParamsPageViewModel : PageViewModelBase
{
    [ObservableProperty] private DateTimeOffset _date;
    [ObservableProperty] private string projectName;
    [ObservableProperty] private string description;
    [ObservableProperty] private string author;
    [ObservableProperty] private decimal maxDeviation;
    [ObservableProperty] private decimal minDeviation;
    [ObservableProperty] private decimal verticalDeviation;
    [ObservableProperty] private decimal localAreaDeviation;
    [ObservableProperty] private int bedLength;
    [ObservableProperty] private int localAreaLength;
    [ObservableProperty] private int localAreaTolerance;
    [ObservableProperty] private int allLengthTolerance;
    [ObservableProperty] private int step;
    [ObservableProperty] private Level model;
    [ObservableProperty] private bool canApplyChanges;
    [ObservableProperty] private bool canCancelChanges;


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

    private IBrush TextBoxBackground()
    {
        return Brushes.Red;
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