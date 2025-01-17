using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.LevelTool;

namespace PryamolineynostNew.ViewModels
{
    public partial class LevelDataPageViewModel : PageViewModelBase
    {
        public ICommand AddRowCommand { get; }
        public ICommand DeleteRowCommand { get; }
        
        
  
        public int SelectedToolIndex { get; set; }

        public ObservableCollection<LevelDataItem> LevelData { get; set; }

        [ObservableProperty]
        private List<DataRow> _dataRows;

        [ObservableProperty]
        private string _selectedTool;


        [ObservableProperty]
        private static ObservableCollection<string> _toolsNameList = new ObservableCollection<string>
        {
            "Уровень",
            "Автоколлиматор"
        };


        public LevelDataPageViewModel(List<Models.LevelTool.DataRow> dataRows)
        {
            DataRows = dataRows;
        }


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
}
