using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Enums;
using PryamolineynostNew.Interfaces;
using PryamolineynostNew.Models.Collimator;
using PryamolineynostNew.Models.LevelTool;


namespace PryamolineynostNew.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewModelBase homePageViewModel;
    [ObservableProperty] private Level _levelModel = new Level();
    [ObservableProperty] private Tools? _selectedTool = null;
    [ObservableProperty] private PageViewModelBase _currentPage;
    [ObservableProperty] private bool isHomePageActive;
    private readonly PageViewModelBase[] _pages;

    public MainWindowViewModel()
    {
        homePageViewModel = new HomePageViewModel(this);
        _pages = new PageViewModelBase[]
        {
            homePageViewModel,
            new LevelParamsPageViewModel(_levelModel),
            new LevelDataPageViewModel(_levelModel),
            new GraphicPageViewModel(),
            new SettingsPageViewModel(),
            new ExitPageViewModel(),
            new CollimatorParamsPageViewModel(),
            new CollimatorDataPageViewModel()
        };
        CurrentPage = _pages[0];
    }

    [RelayCommand]
    public void SetHomePage()
    {
        CurrentPage = _pages[0];
        ActivatePage("Home");
    }

    [RelayCommand]
    private void ExitButton_Click()
    {
     
    }

    public void SetParamsPage()
    {
        if (SelectedTool == null)
            CurrentPage = _pages[0];
        else if (SelectedTool == Tools.Level)
            CurrentPage = _pages[1];
        else if (SelectedTool == Tools.Autocollimator) CurrentPage = _pages[6];
    }

    public void SetDataPage()
    {
        if (SelectedTool == null)
            CurrentPage = _pages[0];
        else if (SelectedTool == Tools.Level)
            CurrentPage = _pages[2];
        else if (SelectedTool == Tools.Autocollimator) CurrentPage = _pages[7];
    }


    public void SetGraphicPage()
    {
        CurrentPage = _pages[3];
    }

    public void SetSettingsPage()
    {
        CurrentPage = _pages[4];
    }

    public void SetExitPage()
    {
        CurrentPage = _pages[5];
    }

    private void ActivatePage(string page)
    {
        IsHomePageActive = page == "Home";
    }
}