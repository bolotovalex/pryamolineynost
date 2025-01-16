using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace PryamolineynostNew.ViewModels
{
    public partial class CollimatorDataPageViewModel : PageViewModelBase
    {
        
        public ObservableCollection<CollimatorDataItem> CollimatorData { get; set; }
        public ICommand AddRowCommand { get; }

        public CollimatorDataPageViewModel()
        {
            // Инициализация данных для таблицы
            CollimatorData = new ObservableCollection<CollimatorDataItem>
            {
                new CollimatorDataItem { Id = 1, Name = "Item 1", Value = 100 },
                new CollimatorDataItem { Id = 2, Name = "Item 2", Value = 200 },
                new CollimatorDataItem { Id = 3, Name = "Item 3", Value = 300 }
            };
            
            AddRowCommand = new RelayCommand(AddRow);
        }
        
        private void AddRow()
        {
            // Создаем новую строку с уникальным ID
            var newId = CollimatorData.Count + 1;
            CollimatorData.Add(new CollimatorDataItem { Id = newId, Name = "New Item", Value = 0 });
        }
    }

    public class CollimatorDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
