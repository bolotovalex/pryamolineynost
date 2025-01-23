using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OxyPlot;
using PryamolineynostNew.Enums;
using PryamolineynostNew.Models;
using PryamolineynostNew.Models.LevelTool;


namespace PryamolineynostNew.ViewModels;

public partial class LevelDataPageViewModel : PageViewModelBase
{

    [ObservableProperty] private List<LevelDataItem> dataRows;
    [ObservableProperty] private Level model;
    [ObservableProperty] private bool isMicrometrSelect;
    private bool isReverseMicrometrSelect;
    [ObservableProperty] private bool isAngleSelect;
    private bool isReverseAngleSelect;
    [ObservableProperty] private bool isAdvancedFieldSelect;
    private bool isReverseStrokeSelect;
    [ObservableProperty] private Units selectedUnitItem;
    [ObservableProperty] private ObservableCollection<LevelDataItem> levelData;


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
                case "Градусы":
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

    public LevelDataPageViewModel(Level level)
    {

        SelectedItemText = AvailableUnits[0];
        Model = level;
        LevelData = Model.DataList;
    }
}

    
