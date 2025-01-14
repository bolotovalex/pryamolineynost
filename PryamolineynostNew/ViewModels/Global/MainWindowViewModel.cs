using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.Enums;
using PryamolineynostNew.Models.LevelTool;
using DataRow = System.Data.DataRow;

namespace PryamolineynostNew.ViewModels
{
    
    
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly PageViewModelBase homePageViewModel;
        private readonly Level levelModel;
        private List<Models.LevelTool.DataRow> _dataRows;
        
        [ObservableProperty]
        private Models.Enums.Tools? _selectedTool = null;

        private readonly PageViewModelBase[] _pages;

        public MainWindowViewModel()
        {
         
            
            homePageViewModel = new HomePageViewModel(this);
            levelModel = new Level();
            _dataRows = levelModel.DataList;
            _pages = new PageViewModelBase[]
            {
                homePageViewModel,
                new LevelParamsPageViewModel(levelModel),
                new LevelDataPageViewModel(_dataRows),
                new GraphicPageViewModel(),
                new SettingsPageViewModel(),
                new ExitPageViewModel(),
                new CollimatorParamsPageViewModel(),
                new CollimatorDataPageViewModel()
            };
            _currentPage = _pages[0];
        }

        [ObservableProperty]
        private PageViewModelBase _currentPage;
        [ObservableProperty]
        private bool isHomePageActive;

        [RelayCommand]
        public void SetHomePage()
        {
            CurrentPage = _pages[0];
            ActivatePage("Home");
        }

        [RelayCommand]
        private void ExitButton_Click()
        {
            // Implementation for ExitButton_Click
        }

        public void SetParamsPage()
        {
            if (SelectedTool == null)
            {
                CurrentPage = _pages[0];
            }
            else if (SelectedTool == Models.Enums.Tools.Level)
            {
                CurrentPage = _pages[1];
            }
            else if (SelectedTool == Models.Enums.Tools.Autocollimator)
            {
                CurrentPage = _pages[6];
            }
        }
        
        public void SetDataPage()
        {
            if (SelectedTool == null)
            {
                CurrentPage = _pages[0];
            }
            else if (SelectedTool == Models.Enums.Tools.Level)
            {
                CurrentPage = _pages[2];
            }
            else if (SelectedTool == Models.Enums.Tools.Autocollimator)
            {
                CurrentPage = _pages[7];
            }
        }

        
        public void SetGraphicPage() => CurrentPage = _pages[3];
        public void SetSettingsPage() => CurrentPage = _pages[4];
        public void SetExitPage() => CurrentPage = _pages[5];

        private void ActivatePage(string page)
        {
            IsHomePageActive = page == "Home";
            // Additional page activation logic
        }
    }
}