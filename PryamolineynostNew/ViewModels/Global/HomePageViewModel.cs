using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Interfaces;


namespace PryamolineynostNew.ViewModels;

public partial class HomePageViewModel : PageViewModelBase
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    public HomePageViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
    }
    
    [ObservableProperty]
    private string _title = "Выберите инструмент";

    
    
    [RelayCommand]
    private void SetLevelTool()
    {
        Title = "Уровень";
        _mainWindowViewModel.SelectedTool = Models.Enums.Tools.Level;
    }

    [RelayCommand]
    private void SetAutocollimatorTool()
    {
        Title = "Автоколлиматор";
        _mainWindowViewModel.SelectedTool = Models.Enums.Tools.Autocollimator;
    }
    
    
}