using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Enums;
using PryamolineynostNew.Models;
using PryamolineynostNew.Models.LevelTool;


namespace PryamolineynostNew.ViewModels;

public partial class LevelDataPageViewModel : PageViewModelBase
{
    
    [ObservableProperty] private List<DataRow> _dataRows;
    
    [ObservableProperty] private bool isMicrometrSelect;
    private bool isReverseMicrometrSelect;
    [ObservableProperty] private bool isAngleSelect;
    private bool isReverseAngleSelect;
    [ObservableProperty] private bool isAdvancedFieldSelect;
    private bool isReverseStrokeSelect;
    [ObservableProperty] private Units selectedUnitItem;
    
    private string _selectedItemText;

    public string[] AvailableUnits { get; } = new string[] { "Микрометры", "Градусы" };

    public string SelectedItemText
    {
        get => _selectedItemText;
        set
        {
            _selectedItemText = value;
            switch (_selectedItemText)
            {
                case "Микрометры":
                    SelectedUnitItem = Units.Micrometer;
                    IsMicrometrSelect = true;
                    IsAngleSelect = false;
                    IsReverseMicrometrSelect = IsReverseStrokeSelect;
                    IsReverseAngleSelect = false;
                    break;
                case "Углы":
                    SelectedUnitItem = Units.Angle;
                    IsAngleSelect = true;
                    IsMicrometrSelect = false;
                    IsReverseAngleSelect = IsReverseStrokeSelect;
                    IsReverseMicrometrSelect = false;
                    break;
                default:
                    SelectedUnitItem = Units.Micrometer;
                    IsMicrometrSelect = true;
                    IsAngleSelect = false;
                    IsReverseMicrometrSelect = IsReverseStrokeSelect;
                    IsReverseAngleSelect = false;
                    break;
            }
        }
    }

    public bool IsReverseMicrometrSelect
    {
        get => isReverseMicrometrSelect && IsMicrometrSelect;
        set 
        {
            SetProperty(ref isReverseMicrometrSelect, value);
        }
    }

    public bool IsReverseAngleSelect
    {
        get => isReverseAngleSelect && IsAngleSelect;
        set
        {
            SetProperty(ref isReverseAngleSelect, value);
        }
    }

    public bool IsReverseStrokeSelect
    {
        get => isReverseStrokeSelect;
        set
        {
            SetProperty(ref isReverseStrokeSelect, value);
            IsReverseMicrometrSelect = isReverseStrokeSelect && IsMicrometrSelect;
            IsReverseAngleSelect = isReverseStrokeSelect && IsAngleSelect;
        }
    }


    [RelayCommand]
    public void AddRowCommand()
    {
        //TODO
    }

    [RelayCommand]
    public void DeleteRowCommand()
    {
        //TODO
    }
    
    public LevelDataPageViewModel()
    {
    }

    public LevelDataPageViewModel(List<DataRow> dataRows)
    {
        // DataRows = dataRows;
        SelectedItemText = AvailableUnits[0];
    }

    public ObservableCollection<LevelDataItem> LevelData { get; set; } = new ObservableCollection<LevelDataItem>()
    {
        new LevelDataItem()
        {
            PointNumber = 1,
            PointPosition = 0,
            ActualProfilePoint = 0.0,
            AdjStraightPoint = 0,
            DeviationSize = 0,
            DeviationPerMeter = 0,
            MeanPointValue = 0,
            FwdPoint = 0,
            RevPoint = 0,
            FwdAngle = 0,
            FwdMinutes = 0,
            FwdSeconds = 0,
            RevAngle = 0,
            RevMinutes = 0,
            RevSeconds = 0
        },
        new LevelDataItem() 
        { 
            PointNumber = 2, 
            PointPosition = 0, 
            ActualProfilePoint = 0.0, 
            AdjStraightPoint = 0,
            DeviationSize = 0, 
            DeviationPerMeter = 0,
            MeanPointValue = 0, 
            FwdPoint = 0, 
            RevPoint = 0,
            FwdAngle = 0,
            FwdMinutes = 0, 
            FwdSeconds = 0,
            RevAngle = 0,
            RevMinutes = 0,
            RevSeconds = 0 
        }
    };

    public class LevelDataItem
    {
        public int PointNumber { get; set; }
        public int PointPosition { get; set; }
        public double ActualProfilePoint { get; set; }
        public decimal AdjStraightPoint { get; set; }
        public decimal DeviationSize { get; set; }
        public decimal DeviationPerMeter { get; set; }
        public decimal MeanPointValue { get; set; }
        public int FwdPoint { get; set; }
        public int RevPoint { get; set; }
        public int FwdAngle { get; set; }
        public int FwdMinutes { get; set; }
        public int FwdSeconds { get; set; }
        public int RevAngle { get; set; }
        public int RevMinutes { get; set; }
        public int RevSeconds { get; set; }
    }
}