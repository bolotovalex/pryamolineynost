using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using PryamolineynostNew.Models.LevelTool;

namespace PryamolineynostNew.ViewModels
{
    public partial class LevelDataPageViewModel : PageViewModelBase
    {
        public ICommand AddRowCommand { get; }
        public ICommand DeleteRowCommand { get; }
        
        public ObservableCollection<LevelDataItem> LevelData { get; set; }

        [ObservableProperty]
        private List<DataRow> _dataRows;


        public LevelDataPageViewModel(List<Models.LevelTool.DataRow> dataRows)
        {
            DataRows = dataRows;
        }


        public class LevelDataItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Value { get; set; }
        }
    }
}
