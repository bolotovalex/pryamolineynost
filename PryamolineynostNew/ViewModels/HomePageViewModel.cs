using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Interfaces;


namespace PryamolineynostNew.ViewModels;

public partial class HomePageViewModel : PageViewModelBase
{
    [ObservableProperty]
    private string _title = "Выберите инструмент";

    [RelayCommand]
    private void SetLevelTool()
    {
        Title = "Уровень";
        MainWindowViewModel.ModelTools = Models.Enums.Tools.Level;
    }

    [RelayCommand]
    private void SetAutocollimatorTool()
    {
        Title = "Автоколлиматор";
        MainWindowViewModel.ModelTools = Models.Enums.Tools.Autocollimator;
    }
    
    
}