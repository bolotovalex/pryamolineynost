using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Enums;
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
        _mainWindowViewModel.SelectedTool = Tools.Level;
    }

    [RelayCommand]
    private void SetAutocollimatorTool()
    {
        Title = "Автоколлиматор";
        _mainWindowViewModel.SelectedTool = Tools.Autocollimator;
    }
    
    
}