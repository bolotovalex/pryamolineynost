using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PryamolineynostNew.Models.LevelTool;

namespace PryamolineynostNew.ViewModels
{
    public partial class CollimatorDataPageViewModel : PageViewModelBase
    {
        
        public ObservableCollection<CollimatorDataItem> CollimatorData { get; set; }

        public CollimatorDataPageViewModel()
        {
            // Инициализация данных для таблицы
            CollimatorData = new ObservableCollection<CollimatorDataItem>
            {
                new CollimatorDataItem { Id = 1, Name = "Item 1", Value = 100 },
                new CollimatorDataItem { Id = 2, Name = "Item 2", Value = 200 },
                new CollimatorDataItem { Id = 3, Name = "Item 3", Value = 300 }
            };
        }
    }

    public class CollimatorDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
