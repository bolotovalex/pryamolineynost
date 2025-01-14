using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PryamolineynostNew.Models.LevelTool;

namespace PryamolineynostNew.ViewModels
{
    public partial class LevelDataPageViewModel : PageViewModelBase
    {
        [ObservableProperty]
        private List<DataRow> _dataRows;
        
        
        public LevelDataPageViewModel(List<Models.LevelTool.DataRow> dataRows){
            DataRows = dataRows; }
    }
}
