using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using PryamolineynostNew.Enums;
using PryamolineynostNew.Models;
using PryamolineynostNew.Models.LevelTool;


namespace PryamolineynostNew.ViewModels;

public partial class LevelDataPageViewModel : PageViewModelBase
{
    public ICommand AddRowCommand { get; }
    public ICommand DeleteRowCommand { get; }
    [ObservableProperty] private List<DataRow> _dataRows;


    [ObservableProperty] private Units _selectedUnitItem;
    private string _selectedItemText;

    public string[] AvailableUnits { get; } = new string[] { "Микрометры", "Углы" };

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
                    break;
                case "Углы":
                    SelectedUnitItem = Units.Angle;
                    break;
                default:
                    SelectedUnitItem = Units.Micrometer;
                    break;
            }
        }
    }

    public LevelDataPageViewModel()
    {
    }

    public LevelDataPageViewModel(List<DataRow> dataRows)
    {
        DataRows = dataRows;
        SelectedItemText = AvailableUnits[0];
    }

    public ObservableCollection<LevelDataItem> LevelData { get; set; }

    public class LevelDataItem
    {
        public int PointNumber { get; }
        public int PointPosition { get; }
        public double ActualProfilePoint { get; }
        public decimal AdjStraightPoint { get; }
        public decimal DeviationSize { get; }
        public decimal DeviationPerMeter { get; }
        public decimal MeanPointValue { get; }
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